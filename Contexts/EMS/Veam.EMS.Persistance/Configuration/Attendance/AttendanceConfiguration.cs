using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<AttendanceC>
    {
        public void Configure(EntityTypeBuilder<AttendanceC> entity)
        {
            entity.HasIndex(e => new { e.EmployeeId, e.WorkDate })
                  .HasName("idx1_AttendanceC");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.EmployeeId)
                .IsRequired()
                .HasColumnName("EmployeeID")
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.LateMin)
                .HasColumnName("Late_Min")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.Ot15)
                .HasColumnName("OT_15")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.Ot3)
                .HasColumnName("OT_3")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.PassCode)
                .IsRequired()
                .HasColumnName("Pass_Code")
                .HasColumnType("char(1)");

            entity.Property(e => e.TimeIn)
                .IsRequired()
                .HasColumnName("Time_In")
                .HasMaxLength(19)
                .IsUnicode(false);

            entity.Property(e => e.TimeOut)
                .HasColumnName("Time_Out")
                .HasMaxLength(19)
                .IsUnicode(false);

            entity.Property(e => e.WorkDate)
                .IsRequired()
                .HasColumnName("Work_Date")
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.WorkDay)
                .HasColumnName("Work_Day")
                .HasColumnType("decimal(2, 1)")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.WorkShift)
                .IsRequired()
                .HasColumnName("Work_Shift")
                .HasMaxLength(5)
                .IsUnicode(false);

        }
    }
}