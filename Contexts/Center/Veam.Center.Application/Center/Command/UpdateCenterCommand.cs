using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;

namespace Veam.Centers.Application.CenterMap
{
    public class UpdateCenterCommand : CenterCommandDto, IRequest
    {

        /// <summary>
        /// any additional property can be here
        /// </summary>
        public class Handler : IRequestHandler<UpdateCenterCommand, Unit>
        {
            private readonly ICenterDbContext _context;
            private readonly IMediator _mediator;

            public Handler(ICenterDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateCenterCommand rq, CancellationToken cancellationToken)
            {
                var entity = await _context.Center
                     .SingleOrDefaultAsync(c => c.Id == rq.CenterId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Domain.Center), rq.CenterId);
                }
               entity.Update(rq.CenterId,rq.CenterName, rq.centerTypeId, rq.SubsideryId, rq.buildingId, rq.description, rq.isHO, rq.user);
                // to do ef update
                _context.Center.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //building updated event
                return Unit.Value;
            }
        }
    }

}

