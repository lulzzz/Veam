using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public class UpdateVendorCommand : VendorCommandDto, IRequest
    {
        public long vendorId { get; set; }
        /// <summary>
        /// any additional property can be here
        /// </summary>
        public class Handler : IRequestHandler<UpdateVendorCommand, Unit>
        {
            private readonly IBaseDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IBaseDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateVendorCommand rq, CancellationToken cancellationToken)
            {
                var entity = await _context.Vendor
                     .SingleOrDefaultAsync(c => c.Id == rq.vendorId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Domain.Vendor), rq.vendorId);
                }

              
                var company = new Company(rq.RegisterCompanyName, rq.Country, rq.GstNo);
                entity.Update(rq.vendorId, company, rq.description, rq.user);
                // to do ef update
                _context.Vendor.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //building updated event
                return Unit.Value;
            }
        }
    }

}

