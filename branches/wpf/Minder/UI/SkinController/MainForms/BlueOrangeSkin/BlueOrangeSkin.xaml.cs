using System;
using System.Windows.Controls;

namespace Minder.UI.SkinController.MainForms
{
    /// <summary>
    /// Interaction logic for BlackOrange.xaml
    /// </summary>
    public partial class BlueOrangeSkin : AbstractMainForm
    {
		public const string SKIN_UNIQUE_CODE = "BLUE_ORANGE_SKIN";
	
        public BlueOrangeSkin()
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
