using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class CheckOutToEmployeeCommand : CheckOutCommandDto, IRequest
    {
        public long employeeId { get; set; }
        public long departmentId { get; set; }
        public long subsideryId { get; set; }
        public string user { get; set; }
        public long assetId { get; private set; }

        public class Handler : IRequestHandler<CheckOutToEmployeeCommand, Unit>
        {
            private readonly IEAMDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IEAMDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CheckOutToEmployeeCommand rq, CancellationToken cancellationToken)
            {

                //var entity = await _context.CheckOut
                //   .FindAsync(rq.checkoutId);
                //if (entity == null)
                //{
                //    throw new NotFoundException(nameof(CheckOut), rq.checkoutId);
                //}

                var reqInfo = new RequestInfo(rq.requestedBy, rq.requestedDate, rq.approvedBy, rq.approveDate);
                var assignmentInfo = new AssignmentInfo(rq.assetConditon, rq.conditionNote);
                var toemp = new CheckOutToEmployee(rq.subsideryId, rq.employeeId, rq.departmentId);

                var entity = new CheckOut();
                entity.CheckOutToEmployee( rq.assetId, rq.checkedOutDate, toemp, assignmentInfo, reqInfo, rq.user);

                //// to do ef update
                _context.CheckOut.Add(entity);
                 await _context.SaveChangesAsync(cancellationToken);
                // //building updated event
                return Unit.Value;
            }
        }
    }



}
