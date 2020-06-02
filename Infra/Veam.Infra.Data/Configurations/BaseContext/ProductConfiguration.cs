using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.Base.Domain;


namespace Veam.Infra.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", schema: "Base");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.productCode)
             .HasMaxLength(3) 
             .IsRequired();

           builder.HasIndex(e => e.productCode) 
             .IsUnique();

            builder.Property(e => e.productName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.description)
                .HasMaxLength(250);

            builder.Property(e => e.uom)
                 .HasMaxLength(25)
             .IsRequired();

            //for FK Constrained

            builder.HasOne(c => c.productCategory)
              .WithMany()
             .HasForeignKey(c => c.CategoryId)
             .IsRequired();

            builder.HasOne(c => c.productType)
             .WithMany()
            .HasForeignKey(c => c.TypeId)
            .IsRequired();
        }
    }

    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductType", schema: "Base");
        }
    }
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory", schema: "Base");
        }
    }
}