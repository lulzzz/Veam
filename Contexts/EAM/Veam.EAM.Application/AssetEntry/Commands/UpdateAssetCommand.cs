using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class UpdateAssetCommand : AssetCommandDto, IRequest
    {
        /// <summary>
        /// any additional property can be here
        /// </summary>
        public long AssetId { get; set; }
        public string user { get; set; }

        public class Handler : IRequestHandler<UpdateAssetCommand, Unit>
        {
            private readonly IEAMDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IEAMDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateAssetCommand rq, CancellationToken cancellationToken)
            {
               
                var entity = await _context.Asset
                   .FindAsync(rq.AssetId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Asset), rq.AssetId);
                }
                var Modal = new AssetModel(rq.modalname, rq.modalnumber, rq.brand, rq.product); 
                 entity.updateAssetInfo(rq.AssetId,rq.assetName,  rq.serialNo,  Modal, rq.user);
               //do not update asset tag here

                // to do ef save// to do ef update
                _context.Asset.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //building updated event
                return Unit.Value;
            }
        }
    }
}
