using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class MasterSectionConfiguration : IEntityTypeConfiguration<MasterSection>
    {
        public void Configure(EntityTypeBuilder<MasterSection> entity)
        {
            entity.HasKey(e => e.SectionId);

            entity.Property(e => e.SectionId).HasColumnName("SectionID");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

            entity.Property(e => e.SectionCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.SectionName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Department)
                .WithMany(p => p.MasterSection)
                .HasForeignKey(d => d.DepartmentId);
        }
    }
}