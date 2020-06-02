using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.CenterRent.Domain;

namespace Veam.Infra.Data
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("Building", schema: "Rent");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.buildingName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.buildingNo)
                .IsRequired()
                .HasMaxLength(2);

            builder.OwnsOne(p => p.address, cfg =>
            {
                cfg.Property(c => c.line1)
                   .HasMaxLength(75)
                   .HasColumnName("add_line1");

                cfg.Property(c => c.line2) 
                    .HasMaxLength(75)
                    .HasColumnName("add_line2");

                cfg.Property(c => c.city) 
                    .HasMaxLength(50)
                    .HasColumnName("add_city");

                cfg.Property(c => c.state) 
                    .HasMaxLength(30)
                    .HasColumnName("add_state");

                cfg.Property(c => c.zip)
                    .HasMaxLength(6)
                    .HasColumnName("add_zip");
            });
        }
    }
    public class MetersConfiguration : IEntityTypeConfiguration<Meters>
    {
        public void Configure(EntityTypeBuilder<Meters> builder)
        {
            builder.ToTable("Meters", schema: "Rent");
        }
    }
    public class MeterTypeConfiguration : IEntityTypeConfiguration<MeterType>
    {
        public void Configure(EntityTypeBuilder<MeterType> builder)
        {
            builder.ToTable("MeterType", schema: "Rent");
        }
    }
}