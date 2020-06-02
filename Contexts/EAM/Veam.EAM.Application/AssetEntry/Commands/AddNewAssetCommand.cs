using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class AddNewAssetCommand : AssetCommandDto, IRequest
    {
        public string user { get; set; }
        /// <summary>
        /// any additional property than buildingcommand can be put here 
        /// </summary>
        public class Handler : IRequestHandler<AddNewAssetCommand, Unit>
        {
            private readonly IEAMDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IEAMDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(AddNewAssetCommand rq, CancellationToken cancellationToken)
            {
                var Modal = new AssetModel(rq.modalname, rq.modalnumber, rq.brand, rq.product);
                var entity = new Asset(rq.assetName, rq.serialNo, Modal, rq.user);
                entity.assetstatusId = 1;
               
                // to do ef save
                _context.Asset.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                #region  //Update default Assettag

                entity.assetTag =  Tagger.DefaultTag(rq.product, rq.brand, entity.Id);
                _context.Asset.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //put a Entity created event here with mediator to publish
                await _mediator.Publish(new AssetCreated { AssetId = entity.Id }, cancellationToken);
                return Unit.Value;
            }
        }
    }

}
