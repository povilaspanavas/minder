/*
 * Created by SharpDevelop.
 * User: Povilas.Panavas
 * Date: 2013-03-05
 * Time: 21:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Minder.UI.Helpers
{
	/// <summary>
	/// Description of MessageBoxHelper.
	/// </summary>
	public class MessageBoxHelper
	{
		public DialogResult ShowErrorOk(string text)
		{
			return MessageBox.Show(text, "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		
		public DialogResult ShowWarningOk(string text)
		{
			return MessageBox.Show(text, "Perspėjimas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}
