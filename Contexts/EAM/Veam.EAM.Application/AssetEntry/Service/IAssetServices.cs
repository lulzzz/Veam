using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public interface IAssetServices
    {
        
        Task<IEnumerable<Asset>> GetAllAsync();
        Task<Asset> GetByIdAsync(long? id);
        Task<Asset> GetEditAsync(long? id);
        // Task<IEnumerable<Product>> getProduct();
       // Task<IEnumerable<SelectListItem>> GetProducts();
    }
}
