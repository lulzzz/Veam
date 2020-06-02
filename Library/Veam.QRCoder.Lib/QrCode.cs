using Microsoft.Extensions.Options;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using Veam.QRCoder.Lib;

namespace QRCodeBitmap
{
    public class QrCode : IQrCode
    {
       // private readonly IOptions<QrModel> QrOptions;
        private readonly string url;

        public QrCode(IOptions<QrModel> QrSettings)
        {
            url = QrSettings.Value.Url;
           // this.QrOptions = QrSettings;
        }

        public Byte[] QrCodebuilder(string txtQRCode,string tag,string tag2)
        {
           // txtQRCode = QrSettings.Value.Url;
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(/*QrOptions.Value.Url*/url + txtQRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return BitmapToBytesCode(qrCodeImage,tag,tag2);
        }

        private static Byte[] BitmapToBytesCode(Bitmap image,string line1,string line2)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Load the original image
                Bitmap bmp = new Bitmap(image);

                // Create a rectangle for the entire bitmap
                RectangleF rectf = new RectangleF(0, 0, bmp.Width, bmp.Height);

                // Create graphic object that will draw onto the bitmap
                Graphics g = Graphics.FromImage(bmp);

                // ------------------------------------------
                // Ensure the best possible quality rendering
                // ------------------------------------------
                // The smoothing mode specifies whether lines, curves, and the edges of filled areas use smoothing (also called antialiasing). 
                // One exception is that path gradient brushes do not obey the smoothing mode. 
                // Areas filled using a PathGradientBrush are rendered the same way (aliased) regardless of the SmoothingMode property.
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // The interpolation mode determines how intermediate values between two endpoints are calculated.
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Use this property to specify either higher quality, slower rendering, or lower quality, faster rendering of the contents of this Graphics object.
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // This one is important
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                // Create string formatting options (used for alignment)
                StringFormat format = new StringFormat()
                {
                    LineAlignment = StringAlignment.Far,//Y Axis
                    Alignment = StringAlignment.Center,//xaxis
                    
                };
               
                // Draw the text onto the image
                g.DrawString($"{line1}" +
                    $"\n {line2}", new Font("Arial", 21), Brushes.Black, rectf, format);
                // g.DrawString("Ratneshsinghhnkjdfjkjjsdkjsjksddjbd", new Font("Arial", 21), Brushes.Black, rectf, format);
                // Flush all graphics changes to the bitmap
                g.Flush();

                // Now save or use the bitmap
                image = bmp;
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        private static Byte[] BitmapToBytesCode(Bitmap image )
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Load the original image
                Bitmap bmp = new Bitmap(image);

                // Create a rectangle for the entire bitmap
                RectangleF rectf = new RectangleF(0, 0, bmp.Width, bmp.Height);

                // Create graphic object that will draw onto the bitmap
                Graphics g = Graphics.FromImage(bmp);

                // ------------------------------------------
                // Ensure the best possible quality rendering
                // ------------------------------------------
                // The smoothing mode specifies whether lines, curves, and the edges of filled areas use smoothing (also called antialiasing). 
                // One exception is that path gradient brushes do not obey the smoothing mode. 
                // Areas filled using a PathGradientBrush are rendered the same way (aliased) regardless of the SmoothingMode property.
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // The interpolation mode determines how intermediate values between two endpoints are calculated.
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Use this property to specify either higher quality, slower rendering, or lower quality, faster rendering of the contents of this Graphics object.
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // This one is important
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                // Create string formatting options (used for alignment)
                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Far
                };

                // Draw the text onto the image
                g.DrawString($"{"hhhhjkj"}" +
                    $"\n {"line2"}", new Font("Arial", 21), Brushes.Black, rectf, format);
                // g.DrawString("Ratneshsinghhnkjdfjkjjsdkjsjksddjbd", new Font("Arial", 21), Brushes.Black, rectf, format);
                // Flush all graphics changes to the bitmap
                g.Flush();

                // Now save or use the bitmap
                image = bmp;
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public Byte[] GenerateFile(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            string fileGuid = Guid.NewGuid().ToString().Substring(0, 4);
            qrCodeData.SaveRawData("wwwroot/qrr/file-" + fileGuid + ".qrr", QRCodeData.Compression.Uncompressed);

            QRCodeData qrCodeData1 = new QRCodeData("wwwroot/qrr/file-" + fileGuid + ".qrr", QRCodeData.Compression.Uncompressed);
            QRCode qrCode = new QRCode(qrCodeData1);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return (BitmapToBytesCode(qrCodeImage));
        }

        public List<KeyValuePair<string, Byte[]>> ViewFile()
        {
            List<KeyValuePair<string, Byte[]>> fileData = new List<KeyValuePair<string, byte[]>>();
            KeyValuePair<string, Byte[]> data;

            string[] files = Directory.GetFiles("wwwroot/qrr");
            foreach (string file in files)
            {
                QRCodeData qrCodeData = new QRCodeData(file, QRCodeData.Compression.Uncompressed);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                Byte[] byteData = BitmapToBytesCode(qrCodeImage);
                data = new KeyValuePair<string, Byte[]>(Path.GetFileName(file), byteData);
                fileData.Add(data);
            }

            return fileData;
        }

    }
}
