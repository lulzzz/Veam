using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class AddAssetPurchaseCommand : AssetPurchaseCommandDto, IRequest
    {
        public string user { get; set; }
        /// <summary>
        /// any additional property than buildingcommand can be put here 
        /// </summary>
        public class Handler : IRequestHandler<AddAssetPurchaseCommand, Unit>
        {
            private readonly IEAMDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IEAMDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(AddAssetPurchaseCommand rq, CancellationToken cancellationToken)
            {
                 
                var entity = new AssetPurchase(rq.billNo,  rq.billedDate, rq.notes, rq.vendorId, rq.user);
                
                // to do ef save
                _context.AssetPurchase.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //put a Entity created event here with mediator to publish
                await _mediator.Publish(new AssetPurchaseCreated { AssetpurchaseId = entity.Id }, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
