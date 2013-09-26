

using System;

namespace Minder.Sql.DBVersionSystem
{
	public interface IDBVersionInformation
	{
		DBVersionAttribute VersionAttribute {get;}
		IDBVersionBody VersionBody {get;}
		DBHistoryAttribute HistoryAttribute {get;}
	}
}
