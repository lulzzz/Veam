using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Veam.Centers.Application.CenterMap
{
    public class AddCenterCommand : CenterCommandDto, IRequest
    {

        /// <summary>
        /// any additional property than buildingcommand can be put here 
        /// </summary>
        public class Handler : IRequestHandler<AddCenterCommand, Unit>
        {
            private readonly ICenterDbContext _context;
            private readonly IMediator _mediator;

            public Handler(ICenterDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(AddCenterCommand rq, CancellationToken cancellationToken)
            {
                var entity = new Domain.Center(rq.CenterName, rq.centerTypeId, rq.SubsideryId, rq.buildingId, rq.description, rq.isHO, rq.user);
                // to do ef save
                _context.Center.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //put a building created event here with mediator to publish
              //     await _mediator.Publish(new CenterCreated { buidingId = entity.Id }, cancellationToken);
                return Unit.Value;
            }
        }
    }

}

