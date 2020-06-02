using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class MasterJobPositionConfiguration : IEntityTypeConfiguration<MasterJobPosition>
    {
        public void Configure(EntityTypeBuilder<MasterJobPosition> entity)
        {
            entity.HasKey(e => e.PositionId);

            entity.Property(e => e.PositionId).HasColumnName("PositionID");

            entity.Property(e => e.PositionCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.PositionName)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}