using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class EmployeeEducationConfiguration : IEntityTypeConfiguration<EmployeeEducation>
    {
        public void Configure(EntityTypeBuilder<EmployeeEducation> entity)
        {
            entity.Property(e => e.EmployeeEducationId).HasColumnName("EmployeeEducationID");

            entity.Property(e => e.ChangedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.EmployeeId)
                .IsRequired()
                .HasColumnName("EmployeeID")
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.LastEducation).HasDefaultValueSql("('1')");

            entity.Property(e => e.MajorId).HasColumnName("MajorID");

            entity.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeEducation)
                .HasForeignKey(d => d.EmployeeId);

            entity.HasOne(d => d.Major)
                .WithMany(p => p.EmployeeEducation)
                .HasForeignKey(d => d.MajorId);
        }

    }
}