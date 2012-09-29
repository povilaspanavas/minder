using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using Core.Tools.GlobalHotKeys;

namespace Minder.UI.SkinController.MainForms
{
    /// <summary>
    /// Interaction logic for WhiteSkin.xaml
    /// </summary>
    public partial class WhiteSkin : Window
    {
        public WhiteSkin()
        {
            InitializeComponent();
           // System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(this);
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
		
		//public void ShowHide(object sender, KeyPressedEventArgs e)
		//{
		//	ShowHide();
		//}
		
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
