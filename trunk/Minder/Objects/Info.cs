/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.09.30
 * Time: 08:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core.Attributes;
using Core.Objects;

namespace Minder.Objects
{
	/// <summary>
	/// Description of Info.
	/// </summary>
	[DbTable("INFO")]
	public class Info : ICoreObject
	{
		int m_id;
		string m_uniqueCode = string.Empty; 
		string m_value1 = string.Empty;
		string m_value2 = string.Empty;
		string m_value3 = string.Empty;
		
		[DBColumnReference("ID"), 
		 PrimaryKey("INFO_SEQ")]
		public int Id {
			get { return m_id; }
			set { m_id = value; }
		}
		
		[DBColumnReference("UNIQUE_CODE")]
		public string UniqueCode {
			get { return m_uniqueCode; }
			set { m_uniqueCode = value; }
		}
		
		[DBColumnReference("VALUE1")]
		public string Value1 {
			get { return m_value1; }
			set { m_value1 = value; }
		}
		
		[DBColumnReference("VALUE2")]
		public string Value2 {
			get { return m_value2; }
			set { m_value2 = value; }
		}
		
		[DBColumnReference("VALUE3")]
		public string Value3 {
			get { return m_value3; }
			set { m_value3 = value; }
		}

	}
}
