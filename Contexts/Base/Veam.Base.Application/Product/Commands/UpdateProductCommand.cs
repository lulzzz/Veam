using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public class UpdateProductCommand : ProductCommandDto, IRequest
    {
        /// <summary>
        /// any additional property can be here
        /// </summary>
        public long productId { get; set; }
        public string user { get; set; }

        public class Handler : IRequestHandler<UpdateProductCommand, Unit>
        {
            private readonly IBaseDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IBaseDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateProductCommand rq, CancellationToken cancellationToken)
            {
               
                var entity = await _context.Product
                   .FindAsync(rq.productId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Product), rq.productId);
                }
               
                entity.Update(rq.productId,rq.productCode, rq.productName, rq.description, rq.CategoryId, rq.TypeId, rq.uom, rq.user);
                // to do ef update
                _context.Product.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //building updated event
                return Unit.Value;
            }
        }
    }
}
