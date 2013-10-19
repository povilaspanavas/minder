using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAFSkelbimaiPrograma.Parser.Plugins
{
    class AdvertDto
    {
        string m_name = string.Empty;
        string m_urlLink = string.Empty;
        string m_date = string.Empty;
        string m_year = string.Empty;
        string m_price = string.Empty;
        string m_column1 = string.Empty;
        string m_column2 = string.Empty;
        bool m_read;
        bool m_mark;
        bool m_deleted;
        string m_image = string.Empty;
        string m_settingsId;
        string m_userId;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public string UrlLink
        {
            get { return m_urlLink; }
            set { m_urlLink = value; }
        }

        public string Date
        {
            get { return m_date; }
            set { m_date = value; }
        }

        public string Year
        {
            get { return m_year; }
            set { m_year = value; }
        }

        public string Price
        {
            get { return m_price; }
            set { m_price = value; }
        }

        public string Column1
        {
            get { return m_column1; }
            set { m_column1 = value; }
        }

        public string Column2
        {
            get { return m_column2; }
            set { m_column2 = value; }
        }

        public bool Read
        {
            get { return m_read; }
            set { m_read = value; }
        }

        public bool Mark
        {
            get { return m_mark; }
            set { m_mark = value; }
        }

        public bool Deleted
        {
            get { return m_deleted; }
            set { m_deleted = value; }
        }

        public string Image
        {
            get { return m_image; }
            set { m_image = value; }
        }

        public string UserId
        {
            get { return m_userId; }
            set { m_userId = value; }
        }

        public string SettingsId
        {
            get { return m_settingsId; }
            set { m_settingsId = value; }
        }
    }
}
