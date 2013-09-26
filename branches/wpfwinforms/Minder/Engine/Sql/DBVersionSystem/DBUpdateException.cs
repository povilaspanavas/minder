
using System;

namespace Minder.Sql.DBVersionSystem
{
	public class DBUpdateException : Exception
	{
		public DBUpdateException(string message) : base(message)
		{
		}
		
		public DBUpdateException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
