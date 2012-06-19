/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.12
 * Time: 21:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

using Minder.Objects;
using Minder.Tools;

namespace Minder.Sql
{
	public class DBConnection : IDisposable
	{
		public static bool TestMode = false;
		
		private SQLiteConnection m_sql_con = null;


		public SQLiteConnection SqlConnection {
			get { return m_sql_con; }
		}
		
		public DBConnection()
		{
			Connect();
		}
		
		
		private void Connect()
		{
			string dbPath = new PathCutHelper()
					.CutExecutableFileFromPath(System.Reflection.Assembly
					                           .GetExecutingAssembly().Location);
			dbPath += @"\..\..\DB\MinderDb.db";
			if (TestMode)
				dbPath = @"..\..\DB\MinderDb.db";
			m_sql_con = new SQLiteConnection(string.Format(@"Data Source={0};Version=3;New=False;Compress=True;", dbPath));
			m_sql_con.Open();
		}
		
		public void Dispose()
		{
			if (m_sql_con == null)
				return;
			m_sql_con.Close();
			m_sql_con.Dispose();
		}
		
		public void ExecuteNonQuery(string txtQuery)
		{
			SQLiteCommand sql_cmd = m_sql_con.CreateCommand();
			sql_cmd.CommandText = txtQuery;
			sql_cmd.ExecuteNonQuery();
		}
		
		public List<Task> LoadTasksForShowing()
		{
			SQLiteCommand sql_cmd = m_sql_con.CreateCommand();
			DateTime now = DateTime.Now;
			sql_cmd.CommandText = string.Format("SELECT ID, NAME, DATE_REMAINDER, SOURCE_ID, SHOWED from task where DATE_REMAINDER <= {0}" +
			                                    "and (SHOWED = 0 or SHOWED is null)",
			                                    DBTypesConverter.ToFullDateStringWithQuotes(now));
			
			IDataReader reader = sql_cmd.ExecuteReader();
			List<Task> tasks = new List<Task>();
			while(reader.Read())
			{
				int id = reader.GetInt32(0);
				string name = reader.GetString(1);
				DateTime date = DateTime.Parse(reader.GetString(2));
				string sourceId = reader.GetString(3);
				tasks.Add(new Task(id, name, date, sourceId));
			}
			return tasks;
		}
		
		public Task NextTaskToShow()
		{
			SQLiteCommand sql_cmd = m_sql_con.CreateCommand();
			sql_cmd.CommandText = string.Format("select id, name, date_remainder, source_id from task where (showed is null or showed = 0) " +
			                                    " order by date_remainder, id", 
			                                    DBTypesConverter.ToFullDateStringWithQuotes(DateTime.Now.AddSeconds(-15)));
			
			IDataReader reader = sql_cmd.ExecuteReader();
			while(reader.Read())
			{
				int id = reader.GetInt32(0);
				string name = reader.GetString(1);
				DateTime date = DateTime.Parse(reader.GetString(2));
				string sourceId = reader.GetString(3);
				return new Task(id, name, date, sourceId);
			}
			return null;
		}
		
		public DateTime? NextDateToShow()
		{
			Task task = NextTaskToShow();
			if (task == null)
				return null;
			else
				return task.DateRemainder;
		}
		
		public int SelectNextInterval()
		{
			DateTime? nextDate = NextDateToShow();
			if (nextDate == null)
				return -1;
			if (nextDate.Value < DateTime.Now)
				return 1; // sutiksėk tuoj pat
			TimeSpan timeSpan = nextDate.Value.Subtract(DateTime.Now);
			if (timeSpan.TotalDays >= 1)
				return -1;
			return (int)timeSpan.TotalMilliseconds;
		}
		
		public void Delete(int id)
		{
			SQLiteCommand sql_cmd = m_sql_con.CreateCommand();
			sql_cmd.CommandText = "DELETE FROM TASK WHERE ID = " + id;
			sql_cmd.ExecuteNonQuery();
		}
		
		public void CreateTable()
		{
			SQLiteCommand sql_cmd = m_sql_con.CreateCommand();
			sql_cmd.CommandText = "CREATE TABLE TASK (ID INTEGER PRIMARY KEY, NAME TEXT, DATE_REMAINDER TEXT, " +
				"SOURCE_ID TEXT, SHOWED INTEGER) ";
			sql_cmd.ExecuteNonQuery();
		}
		
		public SQLiteDataReader ExecuteQuery(string query)
		{
			SQLiteCommand sql_cmd = m_sql_con.CreateCommand();
			sql_cmd.CommandText = query;
			return sql_cmd.ExecuteReader();
		}
	}
}
