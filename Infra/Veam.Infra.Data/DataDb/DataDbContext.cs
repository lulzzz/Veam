using Microsoft.EntityFrameworkCore;
using Veam.Base.Application;
using Veam.Base.Domain;
using Veam.CenterRent.Application;
using Veam.CenterRent.Domain;
using Veam.Centers.Application;
using Veam.Centers.Domain;
using Veam.EAM.Application;
using Veam.EAM.Domain;

namespace Veam.Data
{
    public class DataDbContext : DbContext, ICenterDbContext, IRentDbContext, IBaseDbContext/*, IEAMDbContext*/
    {
        public DataDbContext(DbContextOptions<DataDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        //Icenter
        public DbSet<CenterType> CenterTypes { get; set; }
        public DbSet<Subsidery> Subsideries { get; set; }
        public DbSet<Center> Center { get; set; }
        public DbSet<Hall> Hall { get; set; }
        //IRent
        public DbSet<Building> Building { get; set; }
        public DbSet<Permises> Permises { get; set; }
        // IBase
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Veam.Base.Domain.Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<VendorLine> VendorLine { get; set; }
        ////IEAM asset
        //public DbSet<Asset> Asset { get; set; }
        //public DbSet<AssetStatus> AssetStatus { get; set; }
        //public DbSet<FileDetails> FileDetails { get; set; }
        //public DbSet<AssetUploads> AssetUploads { get; set; }
        ////IEAM purchase
        //public DbSet<AssetPurchase> AssetPurchase { get; set; }
        //public DbSet<PurchaseFiles> PurchaseFiles { get; set; }

        ////IEAM checkout
        ////public DbSet<CheckOut> CheckOut { get; set; }
        //public DbSet<CheckOutToEmployee> CheckOutToEmployee { get; set; }
        //public DbSet<CheckOutToLocation> CheckOutToLocation { get; set; }
        //public DbSet<CheckOutToParentAsset> CheckOutToParentAsset { get; set; }
    }
}