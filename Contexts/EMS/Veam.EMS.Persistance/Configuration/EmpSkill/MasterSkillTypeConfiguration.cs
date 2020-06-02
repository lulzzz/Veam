using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class MasterSkillTypeConfiguration : IEntityTypeConfiguration<MasterSkillType>
    {
        public void Configure(EntityTypeBuilder<MasterSkillType> entity)
        {
            entity.HasKey(e => e.SkillTypeId);

            entity.Property(e => e.SkillTypeId).HasColumnName("SkillTypeID");

            entity.Property(e => e.SkillTypeName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}