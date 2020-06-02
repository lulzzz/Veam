using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class MasterSkillGroupConfiguration : IEntityTypeConfiguration<MasterSkillGroup>
    {
        public void Configure(EntityTypeBuilder<MasterSkillGroup> entity)
        {
            entity.HasKey(e => e.SkillGroupId);

            entity.Property(e => e.SkillGroupId).HasColumnName("SkillGroupID");

            entity.Property(e => e.SkillGroupName)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}