using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.Domain.Core.ValueObjects;

namespace Veam.Base.Application
{
    public class UpdateCompanyAddressCommand : VendorCommandDto, IRequest
    {
        public long vendorId { get; set; }
        /// <summary>
        /// any additional property can be here
        /// </summary>
        public class Handler : IRequestHandler<UpdateCompanyAddressCommand, Unit>
        {
            private readonly IBaseDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IBaseDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateCompanyAddressCommand rq, CancellationToken cancellationToken)
            {
                var entity = await _context.Vendor
                     .SingleOrDefaultAsync(c => c.Id == rq.vendorId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Domain.Vendor), rq.vendorId);
                }

                var BillingAddress = new Address(rq.line1, rq.line2, rq.city, rq.state, rq.zip);
                entity.UpdateRegisteredAddress(rq.vendorId, BillingAddress,  rq.user);
                // to do ef update
                _context.Vendor.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //building updated event
                return Unit.Value;
            }
        }
    }


}

