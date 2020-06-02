using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class EmployeeAddressConfiguration : IEntityTypeConfiguration<EmployeeAddress>
    {
        public void Configure(EntityTypeBuilder<EmployeeAddress> entity)
        {
            entity.Property(e => e.EmployeeAddressId).HasColumnName("EmployeeAddressID");

            entity.Property(e => e.ChangedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.EmployeeId)
                .IsRequired()
                .HasColumnName("EmployeeID")
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.HomeAddress)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(15);

            entity.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeAddress)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeAdress_Employee_EmployeeID");
        }

    }
}