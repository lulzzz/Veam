using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class EmployeeLocationConfiguration : IEntityTypeConfiguration<EmployeeLocation>
    {
        public void Configure(EntityTypeBuilder<EmployeeLocation> entity)
        {
            entity.HasKey(e => new { e.LocationId, e.EmployeeId });

            entity.Property(e => e.LocationId).HasColumnName("LocationID");

            entity.Property(e => e.EmployeeId)
                .HasColumnName("EmployeeID")
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.ChangeDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeLocation)
                .HasForeignKey(d => d.EmployeeId);

        }

    }
}