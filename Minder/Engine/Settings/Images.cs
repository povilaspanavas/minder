/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 08/15/2012
 * Time: 14:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Minder.Engine.Settings
{
    /// <summary>
    /// Description of Images.
    /// </summary>
    public class Images
    {
        public Image GetImage(string name)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Images));
            return ((System.Drawing.Image)(resources.GetObject(name)));
        }

        public BitmapImage GetBitmapImage(string name)
        {
            BitmapImage bmpImage = new BitmapImage();
            bmpImage.BeginInit();
            bmpImage.UriSource = new Uri(
                    string.Format("pack://application:,,,/Resources/{0}.bmp", name), UriKind.RelativeOrAbsolute);
            bmpImage.EndInit();
            return bmpImage;
        }

        public BitmapSource ToBitmapSource(System.Drawing.Bitmap bitmap)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                stream.Position = 0;

                var result = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                result.Freeze();
                return result;
            }
        }
    }
}
