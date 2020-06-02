using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.CenterRent.Domain;

namespace Veam.CenterRent.Application
{
    public class DeleteBuildingCommand : IRequest
    {
        public long buildingId { get; set; }

        public class Handler : IRequestHandler<DeleteBuildingCommand>
        {
            private readonly IRentDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IRentDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Building
                    .FindAsync(request.buildingId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Building), request.buildingId);
                }

                // check if 
                var hasPermise = _context.Permises.Any(o => o.buildingId == entity.Id);
                if (hasPermise)
                {
                    // TODO: Add functional test for this behaviour.
                    // request.Canbedeleted = false; impement it it Query
                    throw new DeleteFailureException(nameof(Building), request.buildingId, "There are existing permise associated with this Building.");
                }

                _context.Building.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);
                //use building Deleted event eher with mediator

                return Unit.Value;
            }
        }
    }
}
