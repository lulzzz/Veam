using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class EmployeeStateConfiguration : IEntityTypeConfiguration<EmployeeState>
    {
        public void Configure(EntityTypeBuilder<EmployeeState> entity)
        {
            entity.HasKey(e => e.EmployeeId);

            entity.Property(e => e.EmployeeId)
                .HasColumnName("EmployeeID")
                .HasMaxLength(30)
                .IsUnicode(false)
                .ValueGeneratedNever();



            entity.Property(e => e.ChangedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.JobFunctionId).HasColumnName("JobFunctionID");

            entity.Property(e => e.JoinDate).HasColumnType("date");

            entity.Property(e => e.LevelId).HasColumnName("LevelID");

            entity.Property(e => e.PositionId).HasColumnName("PositionID");

            entity.Property(e => e.ShiftId).HasColumnName("ShiftID");



            entity.HasOne(d => d.Employee)
                .WithOne(p => p.EmployeeState)
                .HasForeignKey<EmployeeState>(d => d.EmployeeId);

            entity.HasOne(d => d.JobFunction)
                .WithMany(p => p.EmployeeState)
                .HasForeignKey(d => d.JobFunctionId);

            entity.HasOne(d => d.Level)
                .WithMany(p => p.EmployeeState)
                .HasForeignKey(d => d.LevelId);

            entity.HasOne(d => d.Position)
                .WithMany(p => p.EmployeeState)
                .HasForeignKey(d => d.PositionId);

            entity.HasOne(d => d.Shift)
                .WithMany(p => p.EmployeeState)
                .HasForeignKey(d => d.ShiftId);
        }

    }
}