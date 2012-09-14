/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.09.15
 * Time: 01:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Minder.UI.Forms
{
	/// <summary>
	/// Pressing Esc button will close form
	/// </summary>
	public class BasicForm : Form
	{
		public BasicForm() : base()
		{
			this.KeyPreview = true;
			this.KeyUp += delegate(object sender, KeyEventArgs e) {
				if (e.KeyCode == Keys.Escape)
				{
					this.Close();
				}
			};
		}
	}
}
