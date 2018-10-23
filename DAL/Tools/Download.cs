using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DAL.Tools
{
    public class Download
    {
        public async Task<BitmapImage> ImageFromUrl(string url)
        {
            WebClient wc = new WebClient();
            byte[] bytes = await wc.DownloadDataTaskAsync(url);
            MemoryStream ms = new MemoryStream(bytes);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();
            return bitmap;
        }

        
    }
}
