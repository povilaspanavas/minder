﻿/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.17
 * Time: 18:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Core.Forms;
using Minder.Forms.Tasks;
using Minder.Objects;
using Minder.Sql;
using Minder.Static;
using Minder.Tools;
using Minder.UI.Forms.TaskShow;

namespace Minder.Forms.TaskShow
{
	/// <summary>
	/// Description of TaskShowFormPreparer.
	/// </summary>
	public class TaskShowFormPreparer : IFormPreparer
	{
		private TaskShowForm m_form = null;
		private Task m_task;
		private List<RemindLaterValue> m_listRemindLaterValues = null;
		
		public Task Task {
			get { return m_task; }
			set { m_task = value; }
		}
		
		public TaskShowFormPreparer(Task task)
		{
			m_form = new TaskShowForm();
			m_form.Text = "Minder Task";
			m_task = task;
			m_listRemindLaterValues = BuildRemindLaterList();
		}
		
		public static List<RemindLaterValue> BuildRemindLaterList()
		{
			List<RemindLaterValue> listRemindLaterValues = new List<RemindLaterValue>();
			listRemindLaterValues.Add(new RemindLaterValue("5 minutes", 5.0m/60));
			listRemindLaterValues.Add(new RemindLaterValue("10 minutes", 10.0m/60));
			listRemindLaterValues.Add(new RemindLaterValue("15 minutes", 15.0m/60));
			listRemindLaterValues.Add(new RemindLaterValue("30 minutes", 30.0m/60));
			listRemindLaterValues.Add(new RemindLaterValue("1 hour", 1m));
			listRemindLaterValues.Add(new RemindLaterValue("2 hours", 2m));
			listRemindLaterValues.Add(new RemindLaterValue("4 hours", 4m));
			listRemindLaterValues.Add(new RemindLaterValue("8 hours", 8m));
			listRemindLaterValues.Add(new RemindLaterValue("1 day", 24m));
			listRemindLaterValues.Add(new RemindLaterValue("2 days", 24*2m));
			listRemindLaterValues.Add(new RemindLaterValue("1 week", 24*7m));
			return listRemindLaterValues;
		}
		
		public static void AddRemindLaterValuesToComboBox(ComboBox comboBox,
		                                                  List<RemindLaterValue> listRemindLaterValues)
		{
			comboBox.ValueMember = "Name";
			foreach (RemindLaterValue val in listRemindLaterValues) {
				comboBox.Items.Add(val);
			}
		}
		
		public System.Windows.Forms.Form Form
		{
			get {
				return m_form;
			}
		}
		
		public void PrepareForm()
		{
			SetEvents();
			SetTaskText();
			SetRemindLater();
			if (StaticData.Settings.PlaySound)
				PlaySound();
			m_form.ShowDialog();
		}
		
		protected void SetRemindLater()
		{
			// Do not put values twice
			if (m_form.MComboBoxRemindLater.Items.Count < 1)
			{
				AddRemindLaterValuesToComboBox(m_form.MComboBoxRemindLater, m_listRemindLaterValues);
			}
			SelectRemindMeLater(m_form.MComboBoxRemindLater);
		}

		/// <summary>
		/// Select default value
		/// </summary>
		/// <param name="comboBox"></param>
		public static void SelectRemindMeLater(ComboBox comboBox)
		{
			for (int i = 0; i < comboBox.Items.Count; i++) {
				if (StaticData.Settings.RemindMeLaterDefaultValue.Equals((comboBox.Items[i] as RemindLaterValue).Value)) {
					comboBox.SelectedIndex = i;
					break;
				}
			}
		}
		
		private void PlaySound()
		{
			string soundPath = new PathCutHelper()
				.CutExecutableFileFromPath(System.Reflection.Assembly
				                           .GetExecutingAssembly().Location);
			soundPath += @"\"+StaticData.SOUND_FILE_PATH;
			SoundPlayer simpleSound = new SoundPlayer(soundPath);
			simpleSound.Play();
		}
		
		public void SetEvents()
		{
			m_form.OkButton.Click += delegate
			{
				m_task.Showed = true;
				CloseOrOkButton();
			};
			
			//Tiesiog išmečiau iš formos close mygtuką, dabar arba ok arba remainder later.
//			m_form.Closed += delegate
//			{
//				Close();
//			};
			
			m_form.RemainderMeLaterButton.Click += delegate
			{
				m_task.Showed = false;
				if (m_form.MComboBoxRemindLater.SelectedItem != null)
				{
					RemindLaterValue val = m_form.MComboBoxRemindLater.SelectedItem as RemindLaterValue;
					m_task.DateRemainder = DateTime.Now.AddHours((double)val.Value);
				}
				else
					m_task.DateRemainder = DateTime.Now.AddMinutes(10); //Temp
				
				m_task.Update();
				m_form.Close(); //Padarom close, o ant close eventas, kad ok arba close button.
				//tai ir gaunasi, kad remaind me later neveikia.
			};
			
			m_form.ButtonEditTask.Click += delegate {
				// Doesn't work closing, probably because we are in the event of the form we are closing
				this.m_form.Hide();
				new TaskNewEditFormPreparer(true, m_task).PrepareForm();
				this.m_form.Close();
			};
			
			m_form.MComboBoxRemindLater.SelectedValueChanged += delegate { 
				m_form.RemainderMeLaterButton.Select();
			};
			
			m_form.Deactivate += delegate { 
				m_form.Opacity = 0.5;
			};
			m_form.Activated += delegate {
				m_form.Opacity = 1.0;
			};
		}

		private void CloseOrOkButton()
		{
			m_task.Update();
			m_form.Close();
		}
		
		private void SetTaskText()
		{
			if(m_task == null)
				return;
			m_form.TextBox.Text =
				string.Format("Task: {0}{1}{2}Time: {3}", m_task.Text, Environment.NewLine, Environment.NewLine,
				              DBTypesConverter.ToFullDateStringByCultureInfo(m_task.DateRemainder));
		}
	}
}