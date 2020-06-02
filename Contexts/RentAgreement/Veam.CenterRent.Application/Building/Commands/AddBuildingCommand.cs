using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.CenterRent.Domain;
using Veam.Domain.Core.ValueObjects;

namespace Veam.CenterRent.Application
{
    public class AddBuildingCommand : BuildingCommandDto, IRequest
    {
        public string user { get; set; }
        /// <summary>
        /// any additional property than buildingcommand can be put here 
        /// </summary>
        public class Handler : IRequestHandler<AddBuildingCommand, Unit>
        {
            private readonly IRentDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IRentDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(AddBuildingCommand rq, CancellationToken cancellationToken)
            {
               
                
                var address = new Address(rq.Line1, rq.Line2, rq.City, rq.State, rq.Zip);
                var entity = new Building(rq.buildingName, rq.buildingNo, address, rq.user);
                // to do ef save
                _context.Building.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);


                //put a building created event here with mediator to publish
                await _mediator.Publish(new BuildingCreated { buidingId = entity.Id }, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
