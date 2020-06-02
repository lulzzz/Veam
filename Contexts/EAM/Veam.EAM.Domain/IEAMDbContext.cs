using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public interface IEAMDbContext
    {
        //asset
        DbSet<Asset> Asset { get; set; }
        DbSet<AssetStatus> AssetStatus { get; set; }
        DbSet<FileDetails> FileDetails { get; set; }
        DbSet<AssetUploads> AssetUploads { get; set; }
        //purchase
        DbSet<AssetPurchase> AssetPurchase { get; set; }
        DbSet<PurchaseFiles> PurchaseFiles { get; set; }

        //checkout
        DbSet<CheckOut> CheckOut { get; set; }

       // DbSet<CheckOutToEmployee> CheckOutToEmployee { get; set; }
        //DbSet<CheckOutToLocation> CheckOutToLocation { get; set; }
        //DbSet<CheckOutToParentAsset> CheckOutToParentAsset { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
