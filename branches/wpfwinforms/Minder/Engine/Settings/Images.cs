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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Images));
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.StreamSource = resources.GetStream(name);
            bi3.EndInit();
            return bi3;
        }
	}
}
