using System;
using System.Windows.Controls;

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
