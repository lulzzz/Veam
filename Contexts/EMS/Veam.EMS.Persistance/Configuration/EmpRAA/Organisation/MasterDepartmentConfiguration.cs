using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class MasterDepartmentConfiguration : IEntityTypeConfiguration<MasterDepartment>
    {
        public void Configure(EntityTypeBuilder<MasterDepartment> entity)
        {
            entity.HasKey(e => e.DepartmentId);

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            entity.Property(e => e.DepartmentCode)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.DepartmentGroup)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.DepartmentName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }

    }
}