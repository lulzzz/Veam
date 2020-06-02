using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public class DeleteProductCommand : IRequest
    {
        public long productId { get; set; }

        public class Handler : IRequestHandler<DeleteProductCommand>
        {
            private readonly IBaseDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IBaseDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Product
                    .FindAsync(request.productId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Product), request.productId);
                }

                //// check if 
                ////var hasPermise = _context.Product.Any(o => o.buildingId == entity.Id);
                //if (hasPermise)
                //{
                //    // TODO: Add functional test for this behaviour.
                //    // request.Canbedeleted = false; impement it it Query
                //    throw new DeleteFailureException(nameof(Building), request.buildingId, "There are existing permise associated with this Building.");
                //}

                _context.Product.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);
                //use building Deleted event eher with mediator

                return Unit.Value;
            }
        }
    }
}
