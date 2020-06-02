using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class DeleteAssetPurchaseCommand : IRequest
    {
        public long AssetPurchaseId { get; set; }

        public bool IsDeleteable { get; set; } 

        public class Handler : IRequestHandler<DeleteAssetPurchaseCommand>
        {
            private readonly IEAMDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IEAMDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(DeleteAssetPurchaseCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.AssetPurchase
                    .FindAsync(request.AssetPurchaseId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(AssetPurchase), request.AssetPurchaseId);
                }

                //// check if 
                ////var hasPermise = _context.Asset.Any(o => o.buildingId == entity.Id);
                //if (hasPermise)
                //{
                //    // TODO: Add functional test for this behaviour.
                //    // request.Canbedeleted = false; impement it it Query
                //    throw new DeleteFailureException(nameof(Building), request.buildingId, "There are existing permise associated with this Building.");
                //}

                _context.AssetPurchase.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);
                //use building Deleted event eher with mediator

                return Unit.Value;
            }
        }
    }
}
