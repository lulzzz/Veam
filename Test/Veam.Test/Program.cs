using System;
using System.IO;
using System.Text;

class Program
{
    public static class FileSizeFormatter
    {
        static void Main(string[] args)
        {
            // Full file name  
            string fileName = @"C:\Users\dell\Pictures\Icard\Jupitar.Jpg";// @"C:\Temp\OK.zip";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Exists)
            {
                 string size = FileSizeFormatter.FormatSize(fi.Length);
               // string size = ReturnSize(fi.Length, string.Empty);
                Console.WriteLine(size);
            }
            Console.ReadKey();
        }


        // Load all suffixes in an array  
        static readonly string[] suffixes =
        { "Bytes", "KB", "MB", "GB", "TB", "PB" };
        public static string FormatSize(Int64 bytes)
        {
            int counter = 0;
            decimal number = (decimal)bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }
            return string.Format("{0:n1} {1}", number, suffixes[counter]);
        }


        private static string ReturnSize(double size, string sizeLabel)
        {
            if (size > 1024)
            {
                if (sizeLabel.Length == 0)
                    return ReturnSize(size / 1024, "KB");
                else if (sizeLabel == "KB")
                    return ReturnSize(size / 1024, "MB");
                else if (sizeLabel == "MB")
                    return ReturnSize(size / 1024, "GB");
                else if (sizeLabel == "GB")
                    return ReturnSize(size / 1024, "TB");
                else
                    return ReturnSize(size / 1024, "PB");
            }
            else
            {
                if (sizeLabel.Length > 0)
                    return string.Concat(size.ToString("0.00"), sizeLabel);
                else
                    return string.Concat(size.ToString("0.00"), "Bytes");
            }
        }
    }
   
}