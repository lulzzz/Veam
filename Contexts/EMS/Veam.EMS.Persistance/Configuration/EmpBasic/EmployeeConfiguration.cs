using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasIndex(e => e.GlobalId)
                    .HasName("UQ__Employee__A50E8993D0F46EBD")
                    .IsUnique();

            entity.Property(e => e.EmployeeId)
                .HasColumnName("EmployeeID")
                .HasMaxLength(30)
                .IsUnicode(false)
                .ValueGeneratedNever();

            entity.Property(e => e.AvailableFlag).HasDefaultValueSql("('1')");

            entity.Property(e => e.BirthDate).HasColumnType("date");

            entity.Property(e => e.CardId)
                .HasColumnName("CardID")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ChangedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.EmployeeType)
                .IsRequired()
                .HasColumnType("nchar(2)");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);


            entity.Property(e => e.Gender)
                .IsRequired()
                .HasColumnType("nchar(1)");

            entity.Property(e => e.GlobalId)
                .IsRequired()
                .HasColumnName("GlobalID")
                .HasMaxLength(30)
                .IsUnicode(false);



            entity.Property(e => e.HireDate).HasColumnType("date");

            entity.Property(e => e.HireType)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(5);
        }

    }
}