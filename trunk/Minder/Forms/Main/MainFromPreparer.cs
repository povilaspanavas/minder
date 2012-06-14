
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using Autogidas_checker.Forms.Main;
using Core;
using Core.Forms;
using Core.Tools.GlobalHotKeys;
using Core.Tools.ImportExport;
using Core.Tools.Log;

namespace EasyRemainder.Forms.Main
{
	/// <summary>
	/// Description of Main_From_Preparer.
	/// </summary>
	public class MainFromPreparer : IFormPreparer
	{
		private MainForm m_form = null;
		public event TaskData DataEntered;
		public delegate void TaskData(string dataEntered);
		
		public MainFromPreparer()
		{
			m_form = new MainForm();
		}

		public void PrepareForm()
		{
			BackroundWorks();
			SetEvents();
		}

		public void SetEvents()
		{
			
		}
		
		private void BackroundWorks()
		{
			RegisterHotKeys();
		}
		
		private void RegisterHotKeys()
		{
			HotKeys hotKeys = new HotKeys();
			hotKeys.KeyPressed += new EventHandler<KeyPressedEventArgs>(KeyPressed);
			hotKeys.RegisterHotKey(ModifierKeys.Alt, Keys.N);
			m_form.m_textBox.KeyDown += KeyPressedEnter;
		}
		
		private void KeyPressed(object sender, KeyPressedEventArgs e)
		{
			if(m_form.Visible == true)
				m_form.Visible = false;
			else
				m_form.Visible = true;
		}
		
		private void KeyPressedEnter(object sender, KeyEventArgs e)
		{
			if(e.Control == false || e.KeyCode != Keys.Enter)
				return;
			if (DataEntered != null)
				DataEntered(this.m_form.TextBox.Text);
			m_form.Visible = false;
		}
		
		public Form Form {
			get { return m_form;}
		}
	}
}
