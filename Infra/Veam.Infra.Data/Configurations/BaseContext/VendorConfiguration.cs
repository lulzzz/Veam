using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.Base.Domain;

namespace Veam.Infra.Data
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendor", schema: "Base");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.description)
                .HasMaxLength(250);

             
            builder.OwnsOne(p => p.Company, cfg =>
            {
                cfg.Property(c => c.RegisterCompanyName)
                   .HasMaxLength(75)
                   .HasColumnName("company_Name");

                cfg.Property(c => c.Country) 
                    .HasMaxLength(75)
                    .HasColumnName("company_Country");

                cfg.Property(c => c.GstNo) 
                    .HasMaxLength(50)
                    .HasColumnName("company_GstNo");
            });

            builder.OwnsOne(p => p.BillAddress, cfg =>
            {
                cfg.Property(c => c.line1)
                   .HasMaxLength(75)
                   .HasColumnName("add_line1");

                cfg.Property(c => c.line2) 
                    .HasMaxLength(75)
                    .HasColumnName("add_line2");

                cfg.Property(c => c.city) 
                    .HasMaxLength(50)
                    .HasColumnName("add_city");

                cfg.Property(c => c.state) 
                    .HasMaxLength(30)
                    .HasColumnName("add_state");

                cfg.Property(c => c.zip)
                    .HasMaxLength(6)
                    .HasColumnName("add_zip");
            });

            builder.OwnsOne(p => p.OfficeContact, cfg =>
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