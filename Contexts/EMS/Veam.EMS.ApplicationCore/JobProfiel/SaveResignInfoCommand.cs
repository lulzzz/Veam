using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Veam.EMS.Domain;

namespace Veam.EMS.Application.JobProfiel
{
    public class ResignInfoDto
    {
        public long EmployeeID { get; set; }
        public DateTime tDate { get; set; }
        public int tType { get; set; }
        public string tReason { get; set; }
        public string status { get; set; }

    }
    public class SaveResignInfoCommand : ResignInfoDto, IRequest
    {
        public string user { get; set; }
        public long ID { get; set; }

        public class Handler : IRequestHandler<SaveResignInfoCommand, Unit>
        {
            private readonly IEmployeeContext _context;
            private readonly IMediator _mediator;

            public Handler(IEmployeeContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(SaveResignInfoCommand rq, CancellationToken cancellationToken)
            {
                var entity = new ResignInfo(rq.EmployeeID, rq.tDate, rq.tType, rq.tReason, rq.status, rq.ID, rq.user);
                await _context.ResignInfo.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //event
                await _mediator.Publish(new Resigned { Id = entity.Id }, cancellationToken);
                return Unit.Value;
            }
        }
    }

    public class Resigned
    {
        public long Id { get; set; }
    }
}
