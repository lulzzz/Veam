using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.Centers.Domain;

namespace Veam.Infra.Data
{
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.hallName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.hallNo)
               .HasMaxLength(3)
               .IsRequired();

            builder.Property(e => e.floorNo)
                 .HasMaxLength(50)
              .IsRequired();

            builder.Property(e => e.locationNo)
                 .HasMaxLength(5)
             .IsRequired();

          
            builder.Property(e => e.description)
                .HasMaxLength(250);

            //for FK Constrained
          
            builder.HasOne(c => c.center)
             .WithMany(b => b.halls)
             .HasForeignKey(c => c.centerId)
             .IsRequired();
        }
    }

}