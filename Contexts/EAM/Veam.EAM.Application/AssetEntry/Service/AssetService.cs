using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sequel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class AssetService : IAssetServices
    {
        private readonly IEAMDbContext _context;

        public AssetService(IEAMDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {

            var entity = await _context.Asset.Where(b => b.IsActive.Equals(true))
                .Include(x=>x.assetstatus).ToListAsync();

            return entity;
        }

        public async Task<Asset> GetByIdAsync(long? id)
        {
            var entity = await _context.Asset
                .Include(x=>x.assetstatus)
                .Include(x=>x.assetPurchase)
                .FirstOrDefaultAsync(x=>x.Id.Equals(id));

            return entity;
        }
        public async Task<Asset> GetEditAsync(long? id)
        {
            var entity = await _context.Asset.FindAsync(id);

            return entity;
        }

       

    }
}
