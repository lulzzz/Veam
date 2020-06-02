using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class EmployeeImageConfiguration : IEntityTypeConfiguration<EmployeeImage>
    {
        public void Configure(EntityTypeBuilder<EmployeeImage> entity)
        {
            entity.HasKey(e => e.ImageId);

            entity.Property(e => e.ImageId).HasColumnName("ImageID");

            entity.Property(e => e.EmployeeId)
                .IsRequired()
                .HasColumnName("EmployeeID")
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeImage)
                .HasForeignKey(d => d.EmployeeId);
        }

    }
}