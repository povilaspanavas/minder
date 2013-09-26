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
using Core.Tools.GlobalHotKeys;

namespace Minder.UI.SkinController.MainForms
{
    /// <summary>
    /// Interaction logic for WhiteSkin.xaml
    /// </summary>
    public partial class WhiteSkin : AbstractMainForm
    {
    	public const string SKIN_UNIQUE_CODE = "WHITE_SKIN";
    	
        public WhiteSkin()
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
