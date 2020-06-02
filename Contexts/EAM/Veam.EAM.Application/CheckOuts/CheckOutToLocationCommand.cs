using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class CheckOutToLocationCommand : CheckOutCommandDto, IRequest
    {
        public long assetId { get; set; }
        public long centerId { get; set; }
        public long hallId { get; set; }
        public long subsideryId { get; set; }
        public long managerId { get; set; }
 
        public string user { get; set; }

        public class Handler : IRequestHandler<CheckOutToLocationCommand, Unit>
        {
            private readonly IEAMDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IEAMDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CheckOutToLocationCommand rq, CancellationToken cancellationToken)
            {

                //var entity = await _context.CheckOut
                //   .FindAsync(rq.checkoutId);
                //if (entity == null)
                //{
                //    throw new NotFoundException(nameof(CheckOut), rq.checkoutId);
                //}


                var reqInfo = new RequestInfo(rq.requestedBy, rq.requestedDate, rq.approvedBy, rq.approveDate);
                var assignmentInfo = new AssignmentInfo(rq.assetConditon, rq.conditionNote);
                var toloc = new CheckOutToLocation(rq.centerId, rq.hallId, rq.managerId, rq.subsideryId);
                var entity = new CheckOut();
                entity.CheckOutToLocation( rq.checkedOutDate, rq.assetId, toloc, assignmentInfo, reqInfo, rq.user);

                // to do ef save// to do ef update
                _context.CheckOut.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
               // building updated event
                return Unit.Value;
            }
        }
    }
}
