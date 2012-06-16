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
		private MainFromPreparer m_formPreparer = null;
		private TimerLogic m_timerLogic = new TimerLogic();
		
		public TimeController(MainFromPreparer m_formPreparer)
		{
			this.m_formPreparer = m_formPreparer;
			this.m_timerLogic = new TimerLogic();
		}
		
		public void Start()
		{
			m_formPreparer.DataEntered += delegate(string dataEntered) {
				SaveNewTask(dataEntered);
				m_timerLogic.RefreshInterval();
			};
//			m_timerLogic.
		}
		
		void SaveNewTask(string dataEntered)
		{
			Task task = new Task().ParseString(dataEntered);
			task.Save();
		}
		
		
	}
}
