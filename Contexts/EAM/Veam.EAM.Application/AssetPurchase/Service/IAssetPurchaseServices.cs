using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public interface IAssetPurchaseServices
    {
        Task<IEnumerable<AssetPurchase>> GetAllAsync();
        Task<AssetPurchase> GetByIdAsync(long? id);
        Task<AssetPurchase> GetEditAsync(long? id);
    }
}
