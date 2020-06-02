using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public interface IProductService
    {
        IEnumerable<Product> GetList();
        Task<IEnumerable<Product>> GetListAsync();
        Task<Product> GetByIdAsync(long? id);
        Task<Product> GetEditAsync(long? id);
        Task<IEnumerable<ProductCategory>> GetCategoryasync();
        IQueryable<Product> GetQueryable();
        Task<IEnumerable<ProductType>> GetTypeasync();
    }
}
