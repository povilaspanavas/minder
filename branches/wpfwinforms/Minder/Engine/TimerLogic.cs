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
using Minder.Engine.Helpers;
using Minder.Forms.Main;
using Minder.Forms.TaskShow;
using Minder.Objects;
using Minder.Sql;

namespace Minder.Engine
{
	public class TimerLogic
	{
		private static log4net.ILog m_log = log4net.LogManager.GetLogger(typeof(TimerLogic));
		
		private Timer m_timer = null;
		private int m_tick = 7000;
//		private int m_sleepTick = 60*60*1000; // viena valanda
		private int m_sleepTick = 60*60*1000*4; // 4 hours - while testing
		
		public TimerLogic()
		{
			m_timer = new Timer();
			m_timer.Interval = m_tick;
			
			m_timer.Tick += delegate
			{
				m_log.Debug("Tick event happened");
				m_timer.Stop();
				// Commented until find bugs
//				if(MousePositionHelper.MouseNotMoving == false)
//				{
					List<Task> tasksToShow = new DbHelper().LoadTasksForShowing();
					m_log.DebugFormat("Loaded {0} tasks for showing", tasksToShow.Count);
					foreach (Task task in tasksToShow)
					{
						new TaskShowController(task).Window.ShowDialog(); //Įkėliau viską į preparerį.
						m_log.DebugFormat("Showed task with id {0}, name {1}, showTime {2}", 
						                  task.Id, task.Text, DBTypesConverter.ToFullDateStringByCultureInfo(task.DateRemainder));
					}
//				}
				
				SetNewTimerInterval();
				m_timer.Start();
			};
			
			m_timer.Start();
		}

		public void SetNewTimerInterval()
		{
			int interval = new DbHelper().SelectNextInterval();
			if (interval < 0)
				interval = m_sleepTick;
			if (interval == 0)
				interval = 1;
			m_log.DebugFormat("Picked new timer interval which is {0} ms ({1} min.)", 
			                  interval, RoundHelper.Round(interval / 1000.0m / 60.0m, 2));
			m_timer.Interval = interval;
		}
		
		public void RefreshInterval()
		{
			m_timer.Stop();
//			if(MousePositionHelper.MouseNotMoving)
//				m_timer.Interval = 1000 * 60 * 2; //2 minutes
//			else
			SetNewTimerInterval();
			m_timer.Start();
		}
		
	}
}
