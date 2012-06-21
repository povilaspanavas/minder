/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 06/21/2012
 * Time: 21:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core.Forms;

namespace Minder.Forms.Main2
{
	/// <summary>
	/// Description of Main2FormPreparer.
	/// </summary> 
	public class Main2FormPreparer : IFormPreparer
	{
		Main2Form m_form = null;
		
		public Main2FormPreparer()
		{
			m_form = new Main2Form();
			m_form.Title = "Minder";
		}
		
		public System.Windows.Forms.Form Form {
			get {
				throw new NotImplementedException();
			}
		}
		
		public void PrepareForm()
		{
			m_form.Show();
		}
		
		public void SetEvents()
		{
			throw new NotImplementedException();
		}
	}
}
