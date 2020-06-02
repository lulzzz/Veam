using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Veam.Application.Core

//     public class AddBuildingCommand : BuildingCommandDto, IRequest
//{
{

    public class AddDemoCommand : IRequest
    {
        /// <summary>
        /// any additional property than buildingcommand can be put here 
        /// </summary>
        public class Handler : IRequestHandler<AddDemoCommand, Unit>
        {
           
            private readonly IMediator _mediator;

            public Handler( IMediator mediator)
            {
              //  _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(AddDemoCommand rq, CancellationToken cancellationToken)
            {
                string user = "";// to be implemented

                //var entity = new Veam.Centers.Domain.Center(rq.CenterName, rq.centerTypeId, rq.SubsideryId, rq.buildingId, rq.description, rq.isHO, user);
                //// to do ef save
                //_context.Center.Add(entity);
                //await _context.SaveChangesAsync(cancellationToken);


                //put a building created event here with mediator to publish
                //     await _mediator.Publish(new BuildingCreated { buidingId = entity.id }, cancellationToken);
                return Unit.Value;
            }
        }
    }



}
