using Core.Attributes;
using Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvertModel
{
    [DbTable("SP_SETTINGS")]
    public class Settings : ICoreObject
    {
        private int m_id;
        private string m_url = string.Empty;
        private string m_uniqueCode = string.Empty;
        private int m_userId;
        private string m_name = string.Empty;

        [DBColumnReference("ID"), PrimaryKey("SP_SETTINGS_SEQ"),
        PropertyCaption("ID", 0, false)]
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [DBColumnReference("URL") /*PropertyCaption("Nuoroda", 3)*/]
        public string Url
        {
            get { return m_url; }
            set { m_url = value; }
        }

        [DBColumnReference("UNIQUE_CODE"), PropertyCaption("Tinklapis", 4)]
        public string UniqueCode
        {
            get { return m_uniqueCode; }
            set { m_uniqueCode = value; }
        }

        [DBColumnReference("USER_ID"), PropertyCaption("Vartotojas", 1, false)]
        public int UserId
        {
            get { return m_userId; }
            set { m_userId = value; }
        }

        [DBColumnReference("NAME"), PropertyCaption("Pavadinimas", 2)]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
    }
}
