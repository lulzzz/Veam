using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.Centers.Domain;

namespace Veam.Infra.Data
{
    public class CenterConfiguration : IEntityTypeConfiguration<Center>
    {
        public void Configure(EntityTypeBuilder<Center> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.centerName)
                .IsRequired()
                .HasMaxLength(50);

            // for FK Constrained
            builder.HasOne(c => c.centerType)
              .WithMany()
              .HasForeignKey(c => c.centerTypeId)
              .IsRequired();

            // for FK Constrained
            builder.HasOne(c => c.subsidery)
              .WithMany()
              .HasForeignKey(c => c.subsideryId)
              .IsRequired();

            builder.Property(e => e.buildingId)
             .IsRequired();

            builder.Property(e => e.description)
                .HasMaxLength(250);

           
        }


    }
}