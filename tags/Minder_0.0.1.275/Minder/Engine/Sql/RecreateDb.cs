/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.09.13
 * Time: 19:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core;
using Core.DB;
using Minder.Objects;
using NUnit.Framework;

namespace Minder.Engine.Sql
{
	[TestFixture]
	public class RecreateDb
	{
		[Test]
		public void RecreateDb_1()
		{
			ConfigLoader.Load(@"c:\Dokumentai\Projektai\Minder1\Minder\bin\Debug\CoreConfig.xml");
			//Reikia nurodyt pilną, nes testuose jis nesuvokia, kad jo execute katalogas yra debug
			GenericDbHelper.DropAllTables();
			GenericDbHelper.CreateTable(typeof(Task));
		}
	}
}
