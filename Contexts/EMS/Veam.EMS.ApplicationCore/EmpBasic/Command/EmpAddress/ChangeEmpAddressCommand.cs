using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Veam.Domain.Core.ValueObjects;
using Veam.EMS.Domain;

namespace Veam.EMS.Application.EmpBasic
{
    public class ChangeEmpAddressCommand : EmpAddressDto, IRequest
    {
        public string user { get; set; }
        /// <summary>
        /// any additional property than buildingcommand can be put here 
        /// </summary>
        public class Handler : IRequestHandler<ChangeEmpAddressCommand, Unit>
        {
            private readonly IEmployeeContext _context;
            private readonly IMediator _mediator;

            public Handler(IEmployeeContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(ChangeEmpAddressCommand rq, CancellationToken cancellationToken)
            {
                var address = new Address(rq.line1, rq.line2, rq.city, rq.state, rq.zip);
                var entity = new EmployeeAddress(rq.addressId, address, rq.addresssType, rq.EmployeeId, rq.user);

                // to do ef save
                _context.EmployeeAddress.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                //put a Entity created event here with mediator to publish
                await _mediator.Publish(new EmpAddressChanged { Id = entity.Id }, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
