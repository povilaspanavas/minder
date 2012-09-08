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

namespace Minder.UI.SkinController.MainForms.DefaultSkin
{
	/// <summary>
	/// Interaction logic for WpfSkin1.xaml
	/// </summary>
	public partial class DefaultSkinForm : Window, IMainForm
	{
		public DefaultSkinForm()
		{
			InitializeComponent();
			System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(this);
			string imagePath = new PathCutHelper()
					.CutExecutableFileFromPath(System.Reflection.Assembly
					                           .GetExecutingAssembly().Location) + @"\minderico.ico";
			
			this.MImage.Source = new BitmapImage(new Uri(imagePath));
			this.ShowInTaskbar = false;
		}
		
		public TextBox MTextBox {
			get {
				return m_textBox;
			}
		}
		
		public Label MDateLabel {
			get {
				return m_dateLabel;
			}
		}
		
		public Window MWindow {
			get {
				return this;
			}
		}
		
		public void ShowHide(object sender, KeyPressedEventArgs e)
		{
			ShowHide();
		}
		
		public void ShowHide()
		{
			if(MWindow.IsVisible)
			{
				MWindow.Hide();
				MTextBox.SelectAll();
			}
			else
			{
				MWindow.Show();
				MTextBox.SelectAll();
				MTextBox.Focus();
				MWindow.Activate();
			}
		}
	}
}