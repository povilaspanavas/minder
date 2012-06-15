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
using EasyRemainder.Forms.Main;
using EasyRemainder.Objects;
using Minder.Sql;

namespace EasyRemainder.Engine
{
	public class TimerLogic
	{
		private Timer m_timer = null;
		private int m_tick = 7000;
		
		public TimerLogic()
		{
			m_timer = new Timer();
			m_timer.Interval = m_tick;
			
			m_timer.Tick += delegate {
				using (DBConnection connection = new DBConnection())
				{
					List<Task> tasksToShow = connection.LoadData();
					foreach (Task task in tasksToShow) {
						System.Windows.Forms.MessageBox.Show(
							string.Format("Pavadinimas: {0}, Laikas:{1}",
							              task.Text, DBTypesConverter.ToFullDateString(task.DateRemainder)));
					}
					foreach (Task task in tasksToShow) {
						connection.Delete(task.Id);
					}
					connection.SelectFirstTask();
				}
			};
		}
		
	}
}
