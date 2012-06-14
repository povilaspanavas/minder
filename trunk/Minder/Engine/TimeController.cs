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
		public void Start()
		{
			Timer timer = new Timer();
			timer.Interval = 7000;
			timer.Tick += delegate {
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
			timer.Start();
			
			MainFromPreparer preparer = new MainFromPreparer();
			preparer.PrepareForm();
			preparer.DataEntered += delegate(string dataEntered) {
				timer.Stop();
//				timer.Dispose();
				string name = dataEntered.Substring(0, dataEntered.IndexOf("|"));
				string time = dataEntered.Substring(dataEntered.IndexOf("|") + 1);
				int minutes = int.Parse(time);
				DateTime showTime = DateTime.Now.AddMinutes(minutes);
				using (DBConnection connection = new DBConnection())
				{
					connection.ExecuteNonQuery("INSERT INTO TASK (NAME, EXECUTETIME) VALUES('" +
					                           name + "', '" + string.Format("{0:yyyy.MM.dd HH:mm:ss}", showTime) + "')");
					timer.Interval = connection.SelectNextInterval();
					timer.Tick += delegate {
						using (DBConnection connection2 = new DBConnection())
						{
							List<Task> tasksToShow = connection2.LoadData();
							foreach (Task task in tasksToShow) {
								System.Windows.Forms.MessageBox.Show(task.Text);
							}
							foreach (Task task in tasksToShow) {
								connection2.Delete(task.Id);
							}
						}
					};
					timer.Start();
				}
			};
		}
	}
}
