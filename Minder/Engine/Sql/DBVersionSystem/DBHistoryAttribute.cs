
using System;

namespace Minder.Sql.DBVersionSystem
{
	[global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public class DBHistoryAttribute : Attribute
	{
		public DBHistoryAttribute()
		{
		}
	}
}
