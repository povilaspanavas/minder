
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autogidas_checker.Forms.Main;
using Core;
using Core.Forms;
using Core.Forms.LoginForm;
using Core.Tools.Log;
using Core.Web;
using EasyRemainder.Forms.Main;
using EasyRemainder.Objects;
using Minder.Sql;

namespace EasyRemainder
{
	public class MainController
	{
		
	}
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class BootStrap
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Starter();
//			StartEngine();
			Application.Run();
		}
		
		private static void StartEngine()
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
							              task.Name, DBTypesConverter.ToFullDateString(task.DateRemainder)));
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
								System.Windows.Forms.MessageBox.Show(task.Name);
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
		
		private static void Starter()
		{
			ConfigLoader.LoadConfiguration(false);
			new UpdateVersion();
			Loger loger = new Loger();
			loger.LogWrite(string.Format("Program started \n Program version: {0}",
			                             StaticData.VersionCache.Version), LogerType.Info);
			
			MainFromPreparer preparer = new MainFromPreparer();
			preparer.PrepareForm();
		}
		
	}
}
