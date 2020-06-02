using System;
using Veam.Domain.Core.Entity;
using Veam.Domain.Core.ValueObjects;

namespace Veam.EAM.Domain
{
    public class FileDetails : EntityBase//ValueObject<FileDetails>
    {
        private FileDetails() { }
        
        public FileDetails(string fileName, string fileSize, string fileNotes, string fileURL)
        {
            this.fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            this.fileSize = fileSize ?? throw new ArgumentNullException(nameof(fileSize));
            this.fileNotes = fileNotes ?? throw new ArgumentNullException(nameof(fileNotes));
            this.FileUrl = fileURL ?? throw new ArgumentNullException(nameof(fileURL));
        }

      
        public string FileUrl { get; set; }

        public string fileName { get; set; }
        public string fileSize { get; set; }
        public string fileNotes { get; set; }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }

}
