using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class EmployeSkillsConfiguration : IEntityTypeConfiguration<EmployeSkills>
    {
        public void Configure(EntityTypeBuilder<EmployeSkills> entity)
        {
            entity.HasKey(e => new { e.EmployeeId, e.SkillId });

            entity.Property(e => e.EmployeeId)
                .HasColumnName("EmployeeID")
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.SkillId).HasColumnName("SkillID");

            entity.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeSkills)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeSkills_Employee_EmployeeID");

            entity.HasOne(d => d.Skill)
                .WithMany(p => p.EmployeSkills)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("FK_EmployeeSkills_MasterSkill_SkillID");
        }

    }
}