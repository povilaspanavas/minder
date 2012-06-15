﻿/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.14
 * Time: 22:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core.Forms;

namespace Minder.Forms.About
{
	/// <summary>
	/// Description of AboutFormPreparer.
	/// </summary>
	public class AboutFormPreparer : IFormPreparer
	{
		AboutForm m_form = null;
		
		public AboutFormPreparer()
		{
			m_form = new AboutForm();
			m_form.Text = "About";
		}
		
		public System.Windows.Forms.Form Form {
			get {
				return m_form;
			}
		}
		
		public void PrepareForm()
		{
			SetEvents();
			m_form.Show();
		}
		
		public void SetEvents()
		{
		}
	}
}
