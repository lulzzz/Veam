using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public class DeleteVendorLineCommand : IRequest
    {
        public long vendorLineId { get; set; }

       



        public class Handler : IRequestHandler<DeleteVendorLineCommand>
        {
            private readonly IBaseDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IBaseDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(DeleteVendorLineCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.VendorLine
                    .FindAsync(request.vendorLineId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(VendorLine), request.vendorLineId);
                }
                _context.VendorLine.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //use building Deleted event eher with mediator
                // if this VendorLine get vacetd then all the asset associted with it should go in stock
                return Unit.Value;
            }
        }

    }
}

