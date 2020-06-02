using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Veam.Domain.Core.ValueObjects;
using Veam.EMS.Domain;

namespace Veam.EMS.Application.EmpBasic
{
    public class ChangeEmpContactCommand : EmpContactDto, IRequest
    {
        public string user { get; set; }

        public class Handler : IRequestHandler<ChangeEmpContactCommand, Unit>
        {
            private readonly IEmployeeContext _context;
            private readonly IMediator _mediator;
            public Handler(IEmployeeContext employeeContext, IMediator mediator)
            {
                this._context = employeeContext;
                _mediator = mediator;
            }
            public async Task<Unit> Handle(ChangeEmpContactCommand rq, CancellationToken cancellationToken)
            {
                var contact = new Communication(rq.mobilePhone, rq.officePhone,
                    rq.personalEmail, rq.workEmail);

                var entity = new EmployeeContact(rq.contactId, contact, rq.EmployeeId, rq.user);
                _context.EmployeeContact.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //event
                await _mediator.Publish(new EmpContactChanged { Id = entity.Id }, cancellationToken);


                return Unit.Value;
            }
        }
    }
}
}
