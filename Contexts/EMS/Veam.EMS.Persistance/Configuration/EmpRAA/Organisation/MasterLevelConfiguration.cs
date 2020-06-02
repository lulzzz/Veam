using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class MasterLevelConfiguration : IEntityTypeConfiguration<MasterLevel>
    {
        public void Configure(EntityTypeBuilder<MasterLevel> entity)
        {
            entity.HasKey(e => e.LevelId);

            entity.Property(e => e.LevelId).HasColumnName("LevelID");

            entity.Property(e => e.LevelCode)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.LevelName)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);
        }

    }
}