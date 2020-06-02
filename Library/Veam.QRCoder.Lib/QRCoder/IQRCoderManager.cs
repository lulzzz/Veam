using System.Drawing;

namespace Maple.NetCore
{
    public interface IQRCoderManager
    {
        Bitmap BuildQRCodeBitmap(string content, int pixel = 20);
        string BuildQRCodeBase64(string content, int pixel = 20);
    }
}
