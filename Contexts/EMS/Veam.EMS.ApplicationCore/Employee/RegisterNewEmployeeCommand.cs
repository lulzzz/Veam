using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Veam.EMS.Domain;

namespace Veam.EMS.Application
{
    public class EmployeeDto
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
    }

    public class RegisterNewEmployeeCommand : EmployeeDto, IRequest
    {
        public long employeeID { get; set; }
        public string user { get; set; }
        public class Handler : IRequestHandler<RegisterNewEmployeeCommand, Unit>
        {
            private readonly IEmployeeContext _context;
            private readonly IMediator _mediator;

            public Handler(IEmployeeContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(RegisterNewEmployeeCommand rq, CancellationToken cancellationToken)
            {
                var entity = new Employee(rq.Title,rq.FirstName,rq.LastName,rq.Gender,rq.BirthDate,
                    rq.employeeID,rq.user);
                await _context.Employee.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //put a Entity created event here with mediator to publish
                await _mediator.Publish(new NewEmployeeRegistered { Id = entity.Id }, cancellationToken);
                return Unit.Value; 
                
            }
        }
    }

    public class NewEmployeeRegistered
    {
        public long Id { get; set; }
    }
    public class Employeeupdated
    {
        public long Id { get; set; }
    }
}
