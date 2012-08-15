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
using Minder.Forms.TaskShow;
using Minder.Objects;
using Minder.Sql;

namespace Minder.Engine
{
	public class TimerLogic
	{
		private Timer m_timer = null;
		private int m_tick = 7000;
		private int m_sleepTick = 60*60*1000; // viena valanda
		
		public TimerLogic()
		{
			m_timer = new Timer();
			m_timer.Interval = m_tick;
			
			m_timer.Tick += delegate {
				m_timer.Stop();
				using (DBConnection connection = new DBConnection())
				{
					List<Task> tasksToShow = connection.LoadTasksForShowing();
					foreach (Task task in tasksToShow) {
//						System.Windows.Forms.MessageBox.Show(
//							string.Format("Task: {0}, Time:{1}",
//							              task.Text, DBTypesConverter.ToFullDateString(task.DateRemainder)));
						new TaskShowFormPreparer(task).PrepareForm(); //Įkėliau viską į preparerį.
//						task.Showed = true;
//						task.Update();
					}
					
					SetNewTimerInterval(connection);
				}
				m_timer.Start();
			};
			
			m_timer.Start();
		}

		public void SetNewTimerInterval(DBConnection connection)
		{
			int interval = connection.SelectNextInterval();
			if (interval < 0)
				interval = m_sleepTick;
			if (interval == 0)
				interval = 1;
			m_timer.Interval = interval;
		}
		
		public void RefreshInterval()
		{
			m_timer.Stop();
			using (DBConnection connection = new DBConnection())
			{
				SetNewTimerInterval(connection);
			}
			m_timer.Start();
			
		}
		
	}
}
