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

namespace Minder.UI.SkinController.MainForms
{
    /// <summary>
    /// Interaction logic for BlackSkin.xaml
    /// </summary>
    public partial class BlackSkin : AbstractMainForm
    {
    	public const string SKIN_UNIQUE_CODE = "BLACK_SKIN";
    	
        public BlackSkin()
        {
            InitializeComponent();
        }
        
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
    }
}
