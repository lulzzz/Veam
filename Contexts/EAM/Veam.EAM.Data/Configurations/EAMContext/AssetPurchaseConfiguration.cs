using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EAM.Domain;

namespace Veam.Infra.Data
{
    public class AssetPurchaseConfiguration : IEntityTypeConfiguration<AssetPurchase>
    {
        public void Configure(EntityTypeBuilder<AssetPurchase> builder)
        {
            builder.ToTable("AssetPurchase", schema: "EAM");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.notes)
                .HasMaxLength(250);

            builder.Property(e => e.vendorId)
               .IsRequired();

            builder.OwnsOne(p => p.assetBills, cfg =>
            {
                cfg.Property(c => c.billNo)
                 .IsRequired()
                   .HasMaxLength(75)
                   .HasColumnName("company_Name");

                cfg.Property(c => c.billedDate)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("company_Country");
               
            });

          

        }
    }
}