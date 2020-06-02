using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class AddNewAssetToCenterCommand : AssetCommandDto, IRequest
    {
        public long checkoutId { get; set; }
        //common for checkOut

        public DateTime checkedOutDate { get; protected set; }
        //asignmentinfo
        public string assetConditon { get; set; }
        public string conditionNote { get; private set; }
        //request info
        public DateTime approveDate { get; set; }
        public string approvedBy { get; private set; }
        public DateTime requestedDate { get; private set; }
        public string requestedBy { get; private set; }

        //to Location
     
        public long centerId { get; set; }
        public long hallId { get; set; }
        public long subsideryId { get; set; }
        public long managerId { get; set; }

        public string user { get; set; }
        /// <summary>
        /// any additional property than buildingcommand can be put here 
        /// </summary>
        public class Handler : IRequestHandler<AddNewAssetToCenterCommand, Unit>
        {
            private readonly IEAMDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IEAMDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(AddNewAssetToCenterCommand rq, CancellationToken cancellationToken)
            {
                var Modal = new AssetModel(rq.modalname, rq.modalnumber, rq.brand, rq.product);
                var entity = new Asset(rq.assetName, rq.serialNo, Modal, rq.user);
                entity.assetstatusId = 1;
               
                // to do ef save
                _context.Asset.Add(entity);
                await _context.SaveChangesAsync(cancellationToken); 

                // update checkout 
                var reqInfo = new RequestInfo(rq.requestedBy, rq.requestedDate, rq.approvedBy, rq.approveDate);
                var assignmentInfo = new AssignmentInfo(rq.assetConditon, rq.conditionNote);
                var toloc = new CheckOutToLocation(rq.centerId, rq.hallId, rq.managerId, rq.subsideryId);
                var ckentity = new CheckOut(); 
                ckentity.CheckOutToLocation(rq.checkedOutDate, entity.Id, toloc, assignmentInfo, reqInfo, rq.user);
                _context.CheckOut.Add(ckentity);
                await _context.SaveChangesAsync(cancellationToken);

                //update asset with tag id
                entity.assetTag = Tagger.DefaultTag(rq.product, rq.brand, entity.Id);
                _context.Asset.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //put a Entity created event here with mediator to publish
                 await _mediator.Publish(new AssetCreated { AssetId = entity.Id }, cancellationToken);
                return Unit.Value;
            }
        }
    }


}
