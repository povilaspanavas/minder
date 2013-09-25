/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.22
 * Time: 19:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Core.Tools.GlobalHotKeys;
using Minder.Tools;
using Minder.UI.SkinController;

namespace Minder.UI.SkinController.MainForms
{
	public partial class DefaultSkinForm : AbstractMainForm
	{
    	public const string SKIN_UNIQUE_CODE = "DEFAULT_SKIN";
		
    	 public override TextBox MTextBox {
			get {
				return m_textBox;
			}
		}
		
		public override Label MDateLabel {
			get {
				return m_dateLabel;
			}
		}
    	
		public DefaultSkinForm()
		{
			InitializeComponent();
			string imagePath = new PathCutHelper()
					.CutExecutableFileFromPath(System.Reflection.Assembly
					                           .GetExecutingAssembly().Location) + @"\minderico.ico";
			
			this.MImage.Source = new BitmapImage(new Uri(imagePath));
			this.ShowInTaskbar = false;
		}
	}
}