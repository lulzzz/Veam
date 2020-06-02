using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class MasterEducationMajorConfiguration : IEntityTypeConfiguration<MasterEducationMajor>
    {
        public void Configure(EntityTypeBuilder<MasterEducationMajor> entity)
        {
            entity.HasKey(e => e.MajorId);

            entity.Property(e => e.MajorId).HasColumnName("MajorID");

            entity.Property(e => e.DegreeId).HasColumnName("DegreeID");



            entity.Property(e => e.MarjorName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Degree)
                .WithMany(p => p.MasterEducationMajor)
                .HasForeignKey(d => d.DegreeId);
        }

    }
}