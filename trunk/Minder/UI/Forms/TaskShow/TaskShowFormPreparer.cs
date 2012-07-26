﻿/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.17
 * Time: 18:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Media;
using Core.Forms;
using Minder.Objects;
using Minder.Sql;
using Minder.Static;
using Minder.Tools;

namespace Minder.Forms.TaskShow
{
	/// <summary>
	/// Description of TaskShowFormPreparer.
	/// </summary>
	public class TaskShowFormPreparer : IFormPreparer
	{
		TaskShowForm m_form = null;
		
		Task m_task;
		
		public Task Task {
			get { return m_task; }
			set { m_task = value; }
		}
		
		public TaskShowFormPreparer(Task task)
		{
			m_form = new TaskShowForm();
			m_form.Text = "Minder Task";
			m_task = task;
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
			if (StaticData.Settings.PlaySound)
				PlaySound();
			m_form.ShowDialog();
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
				m_task.DateRemainder = DateTime.Now.AddMinutes(10); //Temp
				m_task.Update();
				m_form.Close(); //Padarom close, o ant close eventas, kad ok arba close button.
				//tai ir gaunasi, kad remaind me later neveikia.
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
				              DBTypesConverter.ToFullDateString(m_task.DateRemainder));
		}
	}
}