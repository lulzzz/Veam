using MediatR;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class UpdateAssetWarrantyInfoCommand :  IRequest
    {
        /// <summary>
        /// any additional property can be here
        /// </summary>
        public long AssetId { get; set; }
     

        public int periodinMonths { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public string warrantyBy { get; protected set; }
        public string notes { get; protected set; }

        public string user { get; set; }

        public class Handler : IRequestHandler<UpdateAssetWarrantyInfoCommand, Unit>
        {
            private readonly IEAMDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IEAMDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateAssetWarrantyInfoCommand rq, CancellationToken cancellationToken)
            {

                var entity = await _context.Asset
                   .FindAsync(rq.AssetId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Asset), rq.AssetId);
                }
               // var Modal = new AssetModel(rq.modalname, rq.modalnumber, rq.brand, rq.product);
              //  var Tag = rq.assetTag;
                entity.UpdateWarranty(rq.AssetId,rq.periodinMonths, rq.StartDate,  rq.warrantyBy,  rq.notes);

                #region //update asset tag
                DateTime dt = (DateTime)entity.warranty.EndDate;
                var Endate = dt.ToString("dd/MM/yyyy");
                var yy = dt.ToString("yy");//DateTime.ParseExact(Endate.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yy");
                var mm = dt.ToString("MM");// DateTime.ParseExact(Endate.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM");
                var dd = dt.ToString("dd");// DateTime.ParseExact(Endate.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd");
                var tag = entity.assetTag;
                entity.assetTag = Tagger.TagByWarrantyEnd(tag,yy,mm,dd);
                #endregion

                // to do ef save// to do ef update
                _context.Asset.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //building updated event
                return Unit.Value;
            }
        }
    }

}
