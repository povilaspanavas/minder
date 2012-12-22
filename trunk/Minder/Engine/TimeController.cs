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

namespace Minder.Engine
{

	/// <summary>
	/// Description of TimeController.
	/// </summary>
	public class TimeController
	{
		private MainFormPreparer m_formPreparer = null;
		private TimerLogic m_timerLogic = null;
		
		public TimeController(MainFormPreparer m_formPreparer)
		{
			this.m_formPreparer = m_formPreparer;
			this.m_timerLogic = new TimerLogic();
		}
		
		public void Start()
		{
			m_formPreparer.DataEntered += delegate(string dataEntered) 
			{
				SaveNewTask(dataEntered);
				m_timerLogic.RefreshInterval();
			};
			
			TimeEngine.TaskChangedEvent += delegate 
			{
				m_timerLogic.RefreshInterval();
			};
		}
		
		public void SaveNewTask(string dataEntered)
		{
			Task task = new Task().ParseString(dataEntered);
			if (task != null)
				task.Save();
		}
		
	}
}
