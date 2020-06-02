using System;
using System.Collections.Generic;

namespace QRCodeBitmap
{
    public interface IQrCode
    {
        byte[] QrCodebuilder(string txtQRCode, string tag, string tag2);
        List<KeyValuePair<string, Byte[]>> ViewFile();
        Byte[] GenerateFile(string qrText);
    }
}