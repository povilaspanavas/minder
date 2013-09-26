///*
// * Created by SharpDevelop.
// * User: Ignas
// * Date: 2012.09.13
// * Time: 19:50
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//using System;
//using System.Data;
//using Core;
//using Core.DB;
//using Core.DB.Connections;
//using Minder.Objects;
//using Minder.Sql;
//using NUnit.Framework;
//using System.Collections.Generic;
//
//namespace Minder.Engine.Sql
//{
//	[TestFixture]
//	public class RecreateDb
//	{
//		[Test]
//		public void RecreateDb_1()
//		{
//			ConfigLoader.Load(@"CoreConfig.xml");
//			//Reikia nurodyt pilną, nes testuose jis nesuvokia, kad jo execute katalogas yra debug
//			GenericDbHelper.DropAllTables();
//			GenericDbHelper.CreateTable(typeof(Task));
//			
//			//pvz Core sql
//			
//			//Paprastas direct sql
//			GenericDbHelper.RunDirectSql("");
//			
//			//sql su readeriu
//			
//			using(IConnection con = new ConnectionCollector().GetConnection())
//			{
//				IDataReader reader = con.ExecuteReader(""); //reader
//				con.ExecuteQuery(""); //paprastas
//			}
//			
//			//Objectų loadinimas
//			List<Task> allTasks = GenericDbHelper.Get<Task>(); //Visa lenta
//			Task task = GenericDbHelper.GetById<Task>(1); //Pagal id
//			
//			task = new Task();
//			
//			//Save
//			GenericDbHelper.Save(task);
//			GenericDbHelper.Flush();
//			
//			GenericDbHelper.SaveAndFlush(task); 
//			//Su SQLite laikinai reikia naudoti SaveAndFlush, 
//			//nes ten jis querius dedasi pagal id į dictionarius, 
//			//o kai čia negeruojamas id, jis būna visiem insertam 0
//			//Pataisysiu, kad to nebutu ateityje ir galima bus naudoti be flush. :)
//			
//			//Update
//			GenericDbHelper.Update(task);
//			GenericDbHelper.Flush();
//			GenericDbHelper.UpdateAndFlush(task); //čia tas pats
//			
//			//Delete
//			GenericDbHelper.Delete(task);
//			GenericDbHelper.Flush();
//			GenericDbHelper.DeleteAndFlush(task);
//			
//			Task.DeleteAll();
//		}
//	}
//}
