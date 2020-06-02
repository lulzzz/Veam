using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.CenterRent.Domain;
using Veam.Domain.Core.ValueObjects;

namespace Veam.CenterRent.Application
{
    public class UpdateBuildingCommand : BuildingCommandDto, IRequest
    {
        /// <summary>
        /// any additional property can be here
        /// </summary>

        public string user { get; set; }

        public class Handler : IRequestHandler<UpdateBuildingCommand, Unit>
        {
            private readonly IRentDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IRentDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateBuildingCommand rq, CancellationToken cancellationToken)
            {
                //var entity = await _context.Building
                //     .SingleOrDefaultAsync(c => c.Id == rq.buildingId);
                var entity = await _context.Building
                   .FindAsync(rq.buildingId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Building), rq.buildingId);
                }
                string user = rq.user;
                var address = new Address(rq.Line1, rq.Line2, rq.City, rq.State, rq.Zip);

                entity.Update(rq.buildingId, rq.buildingName, rq.buildingNo, address, user);
                // to do ef update
                _context.Building.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //building updated event
                return Unit.Value;
            }
        }
    }
}
