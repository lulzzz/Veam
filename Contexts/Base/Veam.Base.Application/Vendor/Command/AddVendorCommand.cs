using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Base.Domain;
using Veam.Domain.Core.ValueObjects;

namespace Veam.Base.Application
{
    public class AddVendorCommand : VendorCommandDto, IRequest
    {

        /// <summary>
        /// any additional property than buildingcommand can be put here 
        /// </summary>
        public class Handler : IRequestHandler<AddVendorCommand, Unit>
        {
            private readonly IBaseDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IBaseDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(AddVendorCommand rq, CancellationToken cancellationToken)
            {
                //var OfficeContact = new Communication(rq.mobilePhone, rq.officePhone, rq.personalEmail, rq.workEmail);
                //var BillingAddress = new Address(rq.line1, rq.line2, rq.city, rq.state, rq.zip);
                var company = new Company(rq.RegisterCompanyName,  rq.Country, rq.GstNo);
                var entity = new Vendor(company, /*BillingAddress, OfficeContact,*/ rq.description, rq.user);
                // to do ef save
                _context.Vendor.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //put a building created event here with mediator to publish
             //   await _mediator.Publish(new VendorCreated { vendorId = entity.Id }, cancellationToken);
                return Unit.Value;
            }
        }
    }

}

