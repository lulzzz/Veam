using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;

namespace Veam.Centers.Application.CenterMap
{
    public class DeleteCenterCommand : IRequest
    {
        public long centerId { get; set; }

        public class Handler : IRequestHandler<DeleteCenterCommand>
        {
            private readonly ICenterDbContext _context;
            private readonly IMediator _mediator;

            public Handler(ICenterDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(DeleteCenterCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Center
                    .FindAsync(request.centerId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Domain.Center), request.centerId);
                }

                // check if hall consit this centerId
                var hashalls = _context.Hall.Any(o => o.centerId == entity.Id);
                if (hashalls)
                {
                    // TODO: Add functional test for this behaviour.
                    // request.Canbedeleted = false; impement it it Query
                    throw new DeleteFailureException(nameof(Domain.Center), request.centerId, "There are existing Halls or classroom associated with this Center.");
                }

                _context.Center.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);
                //use building Deleted event eher with mediator

                return Unit.Value;
            }
        }

    }

}