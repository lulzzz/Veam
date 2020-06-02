using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public class ProductService : IProductService
    {
        private readonly IBaseDbContext _context;
       
        public ProductService(IBaseDbContext context)
        {
            _context = context;
        }

        public    IQueryable<Product> GetQueryable()
        {

            var entity =   _context.Product.Include(c => c.productCategory).Include(t => t.productType).AsQueryable();

            return entity;
        }

        public async Task<IEnumerable<Product>> GetListAsync()
        {

            var entity =  _context.Product.Include(c=>c.productCategory).Include(t => t.productType).ToListAsync();
            return await entity;
        }

        public IEnumerable<Product> GetList()
        {

            var entity = _context.Product.Include(c => c.productCategory).Include(t => t.productType).ToList();
            return   entity;
        }


        public async Task<Product> GetByIdAsync(long? id)
        {
            var entity = await _context.Product.Include(c => c.productCategory).Include(t => t.productType).FirstAsync(x=>x.Id.Equals(id));
         
            return entity;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategoryasync()
        {
            var entity = await _context.ProductCategory.ToListAsync();

            return entity;
        }

        public async Task<Product> GetEditAsync(long? id)
        {
            var entity = await _context.Product.FindAsync(id);
         
            return entity;
        }

        public async Task<IEnumerable<ProductType>> GetTypeasync()
        {
            var entity = await _context.ProductType.ToListAsync();

            return entity;
        }
    }
}
