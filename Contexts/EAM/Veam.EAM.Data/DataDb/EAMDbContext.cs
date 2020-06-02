using Microsoft.EntityFrameworkCore;
using Veam.EAM.Application;
using Veam.EAM.Domain;

namespace Veam.Data
{
    public class EAMDbContext : DbContext, IEAMDbContext
    {
        public EAMDbContext(DbContextOptions<EAMDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(EAMDbContext).Assembly);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
 
        //IEAM asset
        public DbSet<Asset> Asset { get; set; }
        public DbSet<AssetStatus> AssetStatus { get; set; }
        public DbSet<FileDetails> FileDetails { get; set; }
        public DbSet<AssetUploads> AssetUploads { get; set; }
        //IEAM purchase
        public DbSet<AssetPurchase> AssetPurchase { get; set; }
        public DbSet<PurchaseFiles> PurchaseFiles { get; set; }

        //IEAM checkout
       public DbSet<CheckOut> CheckOut { get; set; }
       // public DbSet<CheckOutToEmployee> CheckOutToEmployee { get; set; }
        //public DbSet<CheckOutToLocation> CheckOutToLocation { get; set; }
        //public DbSet<CheckOutToParentAsset> CheckOutToParentAsset { get; set; }
    }
}