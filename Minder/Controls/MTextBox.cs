/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.18
 * Time: 22:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Minder.Controls
{
	public class MTextBox : System.Windows.Forms.TextBox
	{
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			// http://support.microsoft.com/kb/320584
			const int WM_KEYDOWN = 0x100;
			if (msg.Msg == WM_KEYDOWN)
			{
				if (keyData.Equals(Keys.Control | Keys.A))
				{
					base.SelectAll();
					return true;
				}
				if (keyData.Equals(Keys.Control | Keys.Back))
				{
					if (SelectionStart - 1 < 0)
						return true;
					int min = Math.Min(SelectionStart, Text.Length - 1);
					int lastSpace = Text.LastIndexOf(' ', min, min);
					if (lastSpace == -1) // we delete all except symbols after selection
					{
						Text = Text.Substring(SelectionStart);
						return true;
					}
					string start =  Text.Substring(0, lastSpace);
					string end = Text.Substring(Math.Min(SelectionStart, Text.Length));
					Text = start + end;
					base.Select(lastSpace, 0);
					return true;
				}
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
