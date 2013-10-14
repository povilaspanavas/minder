using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Non database bo.
/// </summary>
namespace WebSite.Model
{
    public class Token
    {
        private int m_userId;
        private string m_token;
        private DateTime m_dateTo;

        public int UserId
        {
            get { return m_userId; }
        }

        public string TokenValue
        {
            get { return m_token; }
        }

        public DateTime DateTo
        {
            get { return m_dateTo; }
            set { m_dateTo = value; }
        }

        public Token(int userId, string token, DateTime dateTo)
        {
            m_dateTo = dateTo;
            m_token = token;
            m_userId = userId;
        }
    }
}