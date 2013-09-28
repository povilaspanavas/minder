/*
 * Created by SharpDevelop.
 * User: Ignas T60
 * Date: 2013-09-27
 * Time: 18:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Core.Attributes;
using Core.Objects;

namespace AdvertModel
{
	[DbTable("SP_ADVERT")]
	public class Advert : ICoreObject
	{
		int m_id;
		string m_name = string.Empty;
		string m_urlLink = string.Empty;
		string m_date = string.Empty;
		string m_year = string.Empty;
		string m_price = string.Empty;
		string m_column1 = string.Empty;
		string m_column2 = string.Empty;
		bool m_read;
		bool m_mark;
//		bool m_deleted;
		string m_parserFileName = string.Empty;
		DateTime m_advertDate;
		string m_image = string.Empty;
		int m_settingsId;
		int m_userId;

		[PrimaryKey("SP_ADVERT_SEQ"),
		 DBColumnReference("ID"),
		 PropertyCaption("ID", 1, false)]
		public int Id
		{
			get { return m_id; }
			set { m_id = value; }
		}

		[DBColumnReference("NAME"),
		 PropertyCaption("Pavadinimas", 2)]
		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		[DBColumnReference("URL_LINK"),
		 PropertyCaption("Nuoroda", 6)]
		public string UrlLink
		{
			get { return m_urlLink; }
			set { m_urlLink = value; }
		}

		[DBColumnReference("DATA"),
		 PropertyCaption("Data", 3)]
		public string DateA
		{
			get { return m_date; }
			set { m_date = value; }
		}

		[DBColumnReference("AD_YEAR"),
		 PropertyCaption("Metai", 4)]
		public string YearA
		{
			get { return m_year; }
			set { m_year = value; }
		}

		[DBColumnReference("PRICE"),
		 PropertyCaption("Kaina", 5)]
		public string Price
		{
			get { return m_price; }
			set { m_price = value; }
		}

		[DBColumnReference("COLUMN1")]
		public string Column1
		{
			get { return m_column1; }
			set { m_column1 = value; }
		}

		[DBColumnReference("COLUMN2")]
		public string Column2
		{
			get { return m_column2; }
			set { m_column2 = value; }
		}

		[DBColumnReference("READ")]
		public bool Read
		{
			get { return m_read; }
			set { m_read = value; }
		}

		[DBColumnReference("MARK")]
		public bool Mark
		{
			get { return m_mark; }
			set { m_mark = value; }
		}

		[DBColumnReference("ADVERT_DATE")]
		public DateTime AdvertDate
		{
			get { return m_advertDate; }
			set { m_advertDate = value; }
		}

		[DBColumnReference("IMAGE")]
		public string Image
		{
			get { return m_image; }
			set { m_image = value; }
		}

		[DBColumnReference("USER_ID")]
		public int UserId
		{
			get { return m_userId; }
			set { m_userId = value; }
		}

		[DBColumnReference("SETTINGS_ID")]
		public int SettingsId
		{
			get { return m_settingsId; }
			set { m_settingsId = value; }
		}

		public override string ToString()
		{
			return string.Format("[{0}, {1}, {2}, {3}]", m_name, m_urlLink, m_date, m_year);
		}
	}
}