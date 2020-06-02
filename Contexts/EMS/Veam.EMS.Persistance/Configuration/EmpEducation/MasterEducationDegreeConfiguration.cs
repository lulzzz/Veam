using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class MasterEducationDegreeConfiguration : IEntityTypeConfiguration<EducationDegree>
    {
        public void Configure(EntityTypeBuilder<EducationDegree> entity)
        {
            entity.HasKey(e => e.DegreeId);

            entity.HasIndex(e => e.DegreeName)
                .HasName("UQ_MasterEducationDegree_DegreeName")
                .IsUnique();

            entity.Property(e => e.DegreeId).HasColumnName("DegreeID");

            entity.Property(e => e.DegreeName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }

    }
}