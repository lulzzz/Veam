using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public class AddVendorLineCommand : VendorLineCommandDto, IRequest
    {

        /// <summary>
        /// any additional property than buildingcommand can be put here 
        /// </summary>
        public class Handler : IRequestHandler<AddVendorLineCommand, Unit>
        {
            private readonly IBaseDbContext _context;
            private readonly IMediator _mediator;
          
            public Handler(IBaseDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
             
            }

            public async Task<Unit> Handle(AddVendorLineCommand rq, CancellationToken cancellationToken)
            {
                var ContactPerson = new Person(rq.firstName,rq.lastName,rq.middleName,rq.nickName,rq.gender,rq.salutation);
                var PersonContact = new Communication(rq.mobilePhone, rq.officePhone, rq.personalEmail, rq.workEmail);
                var entity = new VendorLine(rq.jobTitle, ContactPerson, PersonContact, rq.vendorId, rq.user);
                // to do ef save
                _context.VendorLine.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //put a building created event here with mediator to publish
                await _mediator.Publish(new VendorLineCreated { vendorLineId = entity.Id }, cancellationToken);
                return Unit.Value;
            }
        }
    }

  
}

