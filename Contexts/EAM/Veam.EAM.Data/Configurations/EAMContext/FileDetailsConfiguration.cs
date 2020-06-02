using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EAM.Domain;

namespace Veam.Infra.Data
{
    public class FileDetailsConfiguration : IEntityTypeConfiguration<FileDetails>
    {
        public void Configure(EntityTypeBuilder<FileDetails> builder)
        {
            builder.ToTable("FileDetails", schema: "EAM");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.fileName)
               .HasMaxLength(100);

            builder.Property(e => e.fileSize)
             .HasMaxLength(50);

            builder.Property(e => e.fileNotes)
               .HasMaxLength(250);

        

        }
    }

}