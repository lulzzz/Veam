using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Veam.EMS.Domain;

namespace Veam.EMS.Application.JobProfile
{
    public class HireInfoDto
    {
        public long EmployeeId { get; set; }
        public string CardId { get; set; }
        public string hireType { get; set; }
        public DateTime HireDate { get; set; }
        public int HireforSubsidery { get; set; }//form readtable
        public string employeeType { get; set; }
    }

    public class SaveHireInfoCommand: HireInfoDto,IRequest
    {
        public int ID { get; set; }
        public string user { get; set; }

        public  class Handler : IRequestHandler<SaveHireInfoCommand, Unit>
        {
            private readonly IEmployeeContext _context;
            private readonly IMediator _mediator;

            public Handler(IEmployeeContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }
            public async Task<Unit> Handle(SaveHireInfoCommand rq, CancellationToken cancellationToken)
            {
                var entity = new HireInfo(rq.EmployeeId,rq.CardId,rq.hireType,rq.HireDate,rq.HireforSubsidery,rq.employeeType,rq.ID,rq.user);
               await _context.HireInfo.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);

                //event
              await  _mediator.Publish(new HireInfoSaved{Id=entity.Id },cancellationToken);
                return Unit.Value;
            }
        }
    }

    public class HireInfoSaved
    {
        public long Id { get; set; }
    }
}
