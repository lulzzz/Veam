using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.CenterRent.Domain;

namespace Veam.CenterRent.Data
{
    public class PermisesConfiguration : IEntityTypeConfiguration<Permises>
    {
        public void Configure(EntityTypeBuilder<Permises> builder)
        {
            builder.ToTable("Permises", schema: "Rent");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.name)
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

            //builder.Property(e => e.buildingId)
            // .IsRequired();

            builder.HasOne(c => c.building)
             .WithMany(b => b.Permises)
             .HasForeignKey(c => c.buildingId)
             .IsRequired();
        }
    }
}