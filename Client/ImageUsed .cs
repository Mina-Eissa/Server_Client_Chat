using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ImageUsed
    {
        public Image image;
        public string name;
        public ImageUsed()
        {
            name = "";
            image = null;
        }
        public void Clear()
        {
            name = "";
            image = null;
        }
        public void ByteArrayToImage1(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
               image = Image.FromStream(ms);
            }
        }
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
        public byte[] ImageToByteArray()
        {
            using (var ms = new MemoryStream())
            {
                this.image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public void Save()
        {
            this.image.Save(this.name, ImageFormat.Png);
        }
    }
}
