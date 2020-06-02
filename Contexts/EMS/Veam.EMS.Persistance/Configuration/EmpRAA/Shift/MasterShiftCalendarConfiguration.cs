using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class MasterShiftCalendarConfiguration : IEntityTypeConfiguration<MasterShiftCalendar>
    {
        public void Configure(EntityTypeBuilder<MasterShiftCalendar> entity)
        {
            entity.HasKey(e => e.WorkDate);

            entity.Property(e => e.WorkDate).HasColumnType("date");

            entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

            entity.Property(e => e.WorkType)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.Shift)
                .WithMany(p => p.MasterShiftCalendar)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("FK_WorkCalendar_MasterShift_ShiftID");
        }
    }
}