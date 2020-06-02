using System;

namespace Veam.Domain.Core.ValueObjects
{
    /// <summary>
    /// IFormFile file, 
    /// FileName= file.FileName
    /// FileSize= file.length
    /// FileUrl= relativepath/FileName
    /// TagName= Manually
    /// </summary>
    public class CustomFile : ValueObject<CustomFile>
    {
        public string FileName { get; protected set; }
        public string Tagname { get; protected set; }
        public string FileUrl { get; protected set; }

        public string FileSize { get; protected set; }

        public bool IsLocked { get; protected set; }

        public CustomFile(string name, string tagname, string fileUrl, string fileSize, bool isLocked = false)
        {
            FileName = name ?? throw new ArgumentNullException(nameof(name));
            Tagname = tagname ?? throw new ArgumentNullException(nameof(tagname));
            FileUrl = fileUrl ?? throw new ArgumentNullException(nameof(fileUrl));
            FileSize = fileSize;//ByteToFileSize(fileSize);
            IsLocked = isLocked;
        }

        public override string ToString() => $"/n{Tagname}";
        

        //private readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
        //private string ByteToFileSize(Int64 bytes)
        //{
        //    int counter = 0;
        //    decimal number = (decimal)bytes;
        //    while (Math.Round(number / 1024) >= 1)
        //    {
        //        number = number / 1024;
        //        counter++;
        //    }
        //    return string.Format("{0:n1} {1}", number, suffixes[counter]);
        //}
    }
}
