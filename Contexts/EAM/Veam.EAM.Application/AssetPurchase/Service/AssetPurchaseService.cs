using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class AssetPurchaseService : IAssetPurchaseServices
    {
        private readonly IEAMDbContext _context;
       
        public AssetPurchaseService(IEAMDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AssetPurchase>> GetAllAsync()
        {

            var entity = await _context.AssetPurchase.ToListAsync();
          
            return entity;
        }

        public async Task<AssetPurchase> GetByIdAsync(long? id)
        {
            var entity = await _context.AssetPurchase.FindAsync(id);
         
            return entity;
        }
        public async Task<AssetPurchase> GetEditAsync(long? id)
        {
            var entity = await _context.AssetPurchase.FindAsync(id);
         
            return entity;
        }
    }
}
