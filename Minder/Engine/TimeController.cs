/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.14
 * Time: 00:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Minder.Forms.Main;
using Minder.Objects;
using Minder.Sql;
using Minder.UI.SkinController;

namespace Minder.Engine
{

	/// <summary>
	/// Description of TimeController.
	/// </summary>
	public class TimeController
	{
		private static log4net.ILog m_log = log4net.LogManager.GetLogger(typeof(TimeController));
		
		private MainFormPreparer m_formPreparer = null;
		private TimerLogic m_timerLogic = null;
		
		public TimeController(MainFormPreparer m_formPreparer)
		{
			this.m_formPreparer = m_formPreparer;
			this.m_timerLogic = new TimerLogic();
		}
		
		public void Start()
		{
			m_formPreparer.DataEntered += delegate(string dataEntered, AbstractMainForm form) 
			{
				SaveNewTask(dataEntered, form);
				m_timerLogic.RefreshInterval();
			};
			
			TimeEngine.TaskChangedEvent += delegate 
			{
				m_timerLogic.RefreshInterval();
			};
			m_log.Debug("TimeController started successfully");
		}
		
		public void SaveNewTask(string dataEntered, AbstractMainForm form)
		{
			Task task = new Task().ParseString(dataEntered);
			if (task != null)
			{
				task.Save();
				form.MTextBox.Text = string.Empty;
				m_log.DebugFormat("New task was saved. Name {0}, date {1}", task.Text, 
			                  DBTypesConverter.ToFullDateStringByCultureInfo(task.DateRemainder));
			}
			
		}
		
	}
}
