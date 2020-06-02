using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class MasterSkillConfiguration : IEntityTypeConfiguration<MasterSkill>
    {
        public void Configure(EntityTypeBuilder<MasterSkill> entity)
        {
            entity.HasKey(e => e.SkillId);

            entity.Property(e => e.SkillId).HasColumnName("SkillID");

            entity.Property(e => e.SkillDescription).HasMaxLength(250);

            entity.Property(e => e.SkillGroupId).HasColumnName("SkillGroupID");

            entity.Property(e => e.SkillName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.SkillTypeId).HasColumnName("SkillTypeID");

            entity.HasOne(d => d.SkillGroup)
                .WithMany(p => p.MasterSkill)
                .HasForeignKey(d => d.SkillGroupId);

            entity.HasOne(d => d.SkillType)
                .WithMany(p => p.MasterSkill)
                .HasForeignKey(d => d.SkillTypeId);
        }
    }
}