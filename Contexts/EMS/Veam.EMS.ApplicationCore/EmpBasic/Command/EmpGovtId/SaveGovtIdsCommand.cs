using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Veam.EMS.Domain;

namespace Veam.EMS.Application.EmpBasic.Command.EmpGovtId
{
    public class GovtIdsDto
    {
        public string IdType { get; set; }
        public string IdNos { get; set; }

        public long EmployeeId { get; set; }
    }

    public class SaveGovtIdsCommand : GovtIdsDto, IRequest
    {
        public long id { get; set; }
        public string user { get; set; }

        public class Handler : IRequestHandler<SaveGovtIdsCommand, Unit>
        {
            private readonly IEmployeeContext _context;
            private readonly IMediator _mediator;

            public Handler(IEmployeeContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }
            public async Task<Unit> Handle(SaveGovtIdsCommand rq, CancellationToken cancellationToken)
            {
                var entity = new EmployeeGovtIds(rq.IdType, rq.IdNos, rq.EmployeeId, rq.id, rq.user);

                if (rq.id == 0)
                {
                    // var entity = new EmployeeGovtIds(rq.IdType, rq.IdNos, rq.EmployeeId, 0, rq.user);
                    _context.EmployeeGovtIds.Add(entity);
                }
                else
                {
                    //  var entity = new EmployeeGovtIds(rq.IdType, rq.IdNos, rq.EmployeeId, rq.id, rq.user);
                    _context.EmployeeGovtIds.Update(entity);
                }
                await _context.SaveChangesAsync(cancellationToken);
                // event

                await _mediator.Publish(new EmpGovtIdsUploaded { Id = entity.Id }, cancellationToken);
                return Unit.Value;
            }
        }
    }

    public class EmpGovtIdsUploaded
    {
        public long Id { get; set; }
    }
}
