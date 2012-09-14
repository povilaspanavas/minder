

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Minder.Sql.DBVersionSystem;

namespace Minder.Sql.DBVersionSystem
{
	public interface IDBVersionBody
	{
		void Execute();
	}
}
