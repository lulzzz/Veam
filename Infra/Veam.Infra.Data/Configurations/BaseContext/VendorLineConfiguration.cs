using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.Base.Domain;

namespace Veam.Infra.Data
{
    public class VendorLineConfiguration : IEntityTypeConfiguration<VendorLine>
    {
        public void Configure(EntityTypeBuilder<VendorLine> builder)
        {
            builder.ToTable("VendorLine", schema: "Base");

            builder.HasKey(e => e.Id);
            //for FK Constrained

            builder.HasOne(c => c.vendor)
             .WithMany(b => b.vendorLines)
             .HasForeignKey(c => c.vendorId)
             .IsRequired();

            builder.Property(e => e.note) 
              .HasMaxLength(250);

            builder.Property(e => e.jobTitle) 
                .HasMaxLength(50);

            builder.OwnsOne(p => p.person, cfg =>
            {
                cfg.Property(c => c.firstName)
                   .HasMaxLength(75)
                   .HasColumnName("person_Fname");

                cfg.Property(c => c.lastName)
                    .HasMaxLength(75)
                    .HasColumnName("person_Lname");

                cfg.Property(c => c.middleName) 
                    .HasMaxLength(50)
                    .HasColumnName("person_Mname");

                cfg.Property(c => c.nickName) 
                  .HasMaxLength(50)
                  .HasColumnName("person_Nname");

                cfg.Property(c => c.gender) 
                  .HasMaxLength(50)
                  .HasColumnName("person_Gender");

                cfg.Property(c => c.salutation) 
                  .HasMaxLength(50)
                  .HasColumnName("person_Salutation");
            });

            builder.OwnsOne(p => p.personContact, cfg =>
            {
                cfg.Property(c => c.mobilePhone)
                   .HasMaxLength(75)
                   .HasColumnName("contact_Mobile");

                cfg.Property(c => c.officePhone) 
                    .HasMaxLength(75)
                    .HasColumnName("contact_Phone");

                cfg.Property(c => c.personalEmail) 
                    .HasMaxLength(50)
                    .HasColumnName("contact_personalEmail");

                cfg.Property(c => c.workEmail) 
                  .HasMaxLength(50)
                  .HasColumnName("contact_workEmail");
            });

           
        }
    }

}