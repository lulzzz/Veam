using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public class AddProductCommand : ProductCommandDto, IRequest
    {
        public string user { get; set; }
        /// <summary>
        /// any additional property than buildingcommand can be put here 
        /// </summary>
        public class Handler : IRequestHandler<AddProductCommand, Unit>
        {
            private readonly IBaseDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IBaseDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(AddProductCommand rq, CancellationToken cancellationToken)
            {

                var entity = new Product(rq.productCode, rq.productName, rq.description, rq.CategoryId, rq.TypeId, rq.uom, rq.user);
                // to do ef save
                _context.Product.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //put a Entity created event here with mediator to publish
                await _mediator.Publish(new ProductCreated { productId = entity.Id }, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
