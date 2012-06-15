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

	/// <summary>
	/// Description of TimeController.
	/// </summary>
	public class TimeController
	{
		private MainFromPreparer m_formPreparer = null;
		
		public TimeController(MainFromPreparer m_formPreparer)
		{
			this.m_formPreparer = m_formPreparer;
		}
		
		public void Start()
		{
			m_formPreparer.DataEntered += delegate(string dataEntered) {
				SaveNewTask(dataEntered);
				RefreshTimer();
			};
		}
		
		void RefreshTimer()
		{
			throw new NotImplementedException();
		}
		
		void SaveNewTask(string dataEntered)
		{
			Task task = ParseString(dataEntered);
			task.Save();
		}
		
		Task ParseString(string dataEntered)
		{
			string name = dataEntered.Substring(0, dataEntered.IndexOf("|"));
			string time = dataEntered.Substring(dataEntered.IndexOf("|") + 1);
			int minutes = int.Parse(time);
			DateTime showTime = DateTime.Now.AddMinutes(minutes);
			return null;
		}
	}
}
