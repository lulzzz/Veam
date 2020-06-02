using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EAM.Domain;

namespace Veam.Infra.Data
{
    public class PurchaseFilesConfiguration : IEntityTypeConfiguration<PurchaseFiles>
    {
        public void Configure(EntityTypeBuilder<PurchaseFiles> builder)
        {
            builder.ToTable("PurchaseFiles", schema: "EAM");
            //builder.HasKey(e => e.Id);
            builder.HasKey(k => new { k.AssetpurchaseId, k.FileId });
          
            builder.HasOne(ap => ap.AssetPurchase)
              .WithMany(p => p.purchaseFiles)
              .HasForeignKey(ap => ap.AssetpurchaseId);


            builder.HasOne(ap => ap.File)
                .WithMany()
                .HasForeignKey(ap => ap.FileId);
            //  .WithMany(p => p.)


        }
    }
}