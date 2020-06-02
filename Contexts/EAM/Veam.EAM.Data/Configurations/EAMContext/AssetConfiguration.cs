using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EAM.Domain;

namespace Veam.Infra.Data
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable("Asset", schema: "EAM");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.assetName)
                .HasMaxLength(150);


            builder.Property(e => e.assetTag)
                .HasMaxLength(150);

            builder.Property(e => e.serialNo)
                .HasMaxLength(150);


            // for FK Constrained
            builder.HasOne(c => c.assetstatus)
              .WithMany()
              .HasForeignKey(c => c.assetstatusId)
              .IsRequired();

            //builder.HasOne(c => c.assetPurchase)
            //  .WithMany()
            //  .HasForeignKey(c => c.assetPurchaseId)
            //  .IsRequired();

            builder.OwnsOne(p => p.assetModel, cfg =>
            {
                cfg.Property(c => c.name)
                   .HasMaxLength(75)
                   .HasColumnName("model_Name");

                cfg.Property(c => c.number) 
                    .HasMaxLength(75)
                    .HasColumnName("model_number");

                cfg.Property(c => c.product) 
                   .HasMaxLength(75)
                   .HasColumnName("model_product");

                cfg.Property(c => c.brand) 
                    .HasMaxLength(50)
                    .HasColumnName("model_brand");
            });

            builder.OwnsOne(p => p.warranty, cfg =>
            {
                cfg.Property(c => c.periodinMonths)
                   .HasMaxLength(75)
                   .HasColumnName("warranty_Months");

                cfg.Property(c => c.StartDate) 
                    .HasMaxLength(75)
                    .HasColumnName("warranty_StartDate");

                cfg.Property(c => c.EndDate) 
                    .HasMaxLength(50)
                    .HasColumnName("warranty_EndDate");

                cfg.Property(c => c.warrantyBy) 
                    .HasMaxLength(30)
                    .HasColumnName("warranty_By");

                cfg.Property(c => c.notes)
                    .HasMaxLength(6)
                    .HasColumnName("warranty_notes");
            });

          

        }
    }
    public class AssetStatusConfiguration : IEntityTypeConfiguration<AssetStatus>
    {
        public void Configure(EntityTypeBuilder<AssetStatus> builder)
        {
            builder.ToTable("AssetStatus", schema: "EAM");

            builder.HasData(
                new AssetStatus { Id = 1, status = "InStock" },
                new AssetStatus { Id = 2, status = "Assigned" },
                new AssetStatus { Id = 3, status = "InMaintenance" },
                new AssetStatus { Id = 4, status = "Archived" }
           );
        }
    }
}