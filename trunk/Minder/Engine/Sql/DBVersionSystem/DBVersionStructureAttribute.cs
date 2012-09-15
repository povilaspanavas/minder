
using System;

namespace Minder.Sql.DBVersionSystem
{
	[global::System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	public class DBVersionStructureAttribute : DBVersionAttribute
	{
		public DBVersionStructureAttribute(int version, string comment, string date)
			:base (version, comment, date) 
		{
			
		}
	}
}
