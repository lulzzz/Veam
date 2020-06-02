using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EAM.Domain;

namespace Veam.Infra.Data
{
    public class AssetUploadsConfiguration : IEntityTypeConfiguration<AssetUploads>
    {
        public void Configure(EntityTypeBuilder<AssetUploads> builder)
        {
            builder.ToTable("AssetUploads", schema: "EAM");
            builder.HasKey(k => new { k.assetId, k.FileId });

           
            builder.HasOne(ap => ap.asset)
              .WithMany(p => p.assetUploads)
              .HasForeignKey(ap => ap.assetId)
              .IsRequired();


            builder.HasOne(ap => ap.files)
                .WithMany()
                .HasForeignKey(ap => ap.assetId)
                .IsRequired();
        }
    }

}