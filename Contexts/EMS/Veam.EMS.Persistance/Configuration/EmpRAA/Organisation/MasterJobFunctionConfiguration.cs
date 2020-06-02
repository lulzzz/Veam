using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class MasterJobFunctionConfiguration : IEntityTypeConfiguration<MasterJobFunction>
    {
        public void Configure(EntityTypeBuilder<MasterJobFunction> entity)
        {
            entity.HasKey(e => e.JobFunctionId);

            entity.Property(e => e.JobFunctionId).HasColumnName("JobFunctionID");

            entity.Property(e => e.FunctionCode)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.FunctionName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.SectionId).HasColumnName("SectionID");

            entity.HasOne(d => d.Section)
                .WithMany(p => p.MasterJobFunction)
                .HasForeignKey(d => d.SectionId);
        }

    }
}