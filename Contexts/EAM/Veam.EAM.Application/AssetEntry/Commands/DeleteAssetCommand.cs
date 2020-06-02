using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class DeleteAssetCommand : IRequest
    {
        public long AssetId { get; set; }

        public class Handler : IRequestHandler<DeleteAssetCommand>
        {
            private readonly IEAMDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IEAMDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Asset
                    .FindAsync(request.AssetId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Asset), request.AssetId);
                }

                //// check if 
                ////var hasPermise = _context.Asset.Any(o => o.buildingId == entity.Id);
                //if (hasPermise)
                //{
                //    // TODO: Add functional test for this behaviour.
                //    // request.Canbedeleted = false; impement it it Query
                //    throw new DeleteFailureException(nameof(Building), request.buildingId, "There are existing permise associated with this Building.");
                //}

                _context.Asset.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);
                //use building Deleted event eher with mediator

                return Unit.Value;
            }
        }
    }
}
