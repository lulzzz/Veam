using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;

namespace Veam.Centers.Application.CenterMap
{
    public class UpdateHallCommand : HallCommandDto, IRequest
    {
        public long HallId { get; set; }
        /// <summary>
        /// any additional property can be here
        /// </summary>
        public class Handler : IRequestHandler<UpdateHallCommand, Unit>
        {
            private readonly ICenterDbContext _context;
            private readonly IMediator _mediator;

            public Handler(ICenterDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateHallCommand rq, CancellationToken cancellationToken)
            {
                var entity = await _context.Hall
                     .SingleOrDefaultAsync(c => c.Id == rq.HallId, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Domain.Hall), rq.HallId);
                }
                rq.locationNo = entity.locationNo; // assgning location no as of existing
                entity.Update(rq.HallId, rq.hallName, rq.hallNo, rq.floorNo, rq.locationNo, rq.description, rq.centerId, rq.user);
                // to do ef update
                _context.Hall.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //Entity updated event
                return Unit.Value;
            }
        }
    }

}

