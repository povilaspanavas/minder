using Core.Attributes;
using Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Model
{
    [DbTable("SP_RESTORE_PASS")]
    public class RestorePasswordHash : ICoreObject
    {
        private int m_id;
        private int m_userId;
        private string m_hashCode;
        private DateTime m_dateTo;

        [PrimaryKey("SP_RESTORE_PASS_SEQ"), DBColumnReference("ID")]
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [DBColumnReference("USER_ID")]
        public int UserId
        {
            get { return m_userId; }
            set { m_userId = value; }
        }

        [DBColumnReference("HASH_CODE")]
        public string HashCode
        {
            get { return m_hashCode; }
            set { m_hashCode = value; }
        }

        [DBColumnReference("DATE_TO")]
        public DateTime DateTo
        {
            get { return m_dateTo; }
            set { m_dateTo = value; }
        }
    }
}