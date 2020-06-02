using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class AttachBillCopyCommand :  IRequest
    {
        /// <summary>
        /// any additional property can be here
        /// </summary>
        public long AssetpurchaseId { get; set; }
        public string user { get; set; }

        public string FileUrl { get; set; }
        public string fileName { get; set; }
        public string fileSize { get; set; }
        public string fileNotes { get; set; }

        public class Handler : IRequestHandler<AttachBillCopyCommand, Unit>
        {
            private readonly IEAMDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IEAMDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(AttachBillCopyCommand rq, CancellationToken cancellationToken)
            {

                var entity = await _context.AssetPurchase
                   .FindAsync(rq.AssetpurchaseId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(AssetPurchase), rq.AssetpurchaseId);
                }
            
                entity.UploadBillCopy(rq.AssetpurchaseId,rq.fileName, rq.fileSize, rq.fileNotes,    rq.FileUrl);
                // to do ef save// to do ef update
                _context.AssetPurchase.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //building updated event
                return Unit.Value;
            }
        }
    }

}
