using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;

namespace Veam.Centers.Application.CenterMap
{
    public class DeleteHallCommand : IRequest
    {
        public long hallId { get; set; }


        public class Handler : IRequestHandler<DeleteHallCommand>
        {
            private readonly ICenterDbContext _context;
            private readonly IMediator _mediator;

            public Handler(ICenterDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(DeleteHallCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Hall
                    .FindAsync(request.hallId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Domain.Hall), request.hallId);
                }
                _context.Hall.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //use building Deleted event eher with mediator
                // if this hall get vacetd then all the asset associted with it should go in stock
                return Unit.Value;
            }
        }

    }
}


