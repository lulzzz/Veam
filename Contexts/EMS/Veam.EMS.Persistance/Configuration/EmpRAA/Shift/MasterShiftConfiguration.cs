using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class MasterShiftConfiguration : IEntityTypeConfiguration<MasterShift>
    {
        public void Configure(EntityTypeBuilder<MasterShift> entity)
        {
            entity.HasKey(e => e.ShiftId);

            entity.Property(e => e.ShiftId)
                .HasColumnName("ShiftID")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.ShiftName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}