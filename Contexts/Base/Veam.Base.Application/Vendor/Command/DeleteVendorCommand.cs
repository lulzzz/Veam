using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public class DeleteVendorCommand : IRequest
    {
        public long vendorId { get; set; }



        public class Handler : IRequestHandler<DeleteVendorCommand>
        {
            private readonly IBaseDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IBaseDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Vendor
                    .FindAsync(request.vendorId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Vendor), request.vendorId);
                }

                // check if hall consit this centerId
                //var hashalls = _context.VendorLine.Any(o => o.vendorId == entity.Id);
                //if (hashalls)
                //{
                //    // TODO: Add functional test for this behaviour.
                //    // request.Canbedeleted = false; impement it it Query
                //    throw new DeleteFailureException(nameof(Domain.Center), request.centerId, "There are existing Halls or classroom associated with this Center.");
                //}

                _context.Vendor.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);
                //use building Deleted event eher with mediator

                return Unit.Value;
            }
        }
    }

}

