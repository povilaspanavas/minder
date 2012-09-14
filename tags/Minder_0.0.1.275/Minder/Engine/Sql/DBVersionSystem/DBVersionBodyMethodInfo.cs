

using System;
using System.Reflection;

namespace Minder.Sql.DBVersionSystem
{
	public class DBVersionBodyDelegate : IDBVersionBody
	{
		public void Execute()
		{
		}
	}
	
	public class DBVersionBodyMethodInfo : IDBVersionBody
	{
		MethodInfo m_methodInfo = null;
		
		public DBVersionBodyMethodInfo(MethodInfo methodInfo)
		{
			if (methodInfo == null)
				throw new ArgumentNullException();
			this.m_methodInfo = methodInfo;
		}
		
		public void Execute()
		{
			object o = Activator.CreateInstance(m_methodInfo.DeclaringType);
			m_methodInfo.Invoke(o, null);
		}
	}
}
