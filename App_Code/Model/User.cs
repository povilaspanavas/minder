using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Objects;
using Core.Attributes;

namespace WebSite.Model
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    [DbTable("SP_USER")]
    public class User : ICoreObject
    {
        private int m_id;
        private string m_email = string.Empty;
        private string m_userName = string.Empty;
        private string m_passwordHash = string.Empty;
        private bool m_admin = false;
        private bool m_tempPass = false;
        private bool m_blocked = false;

        [DBColumnReference("ID"), PrimaryKey("SP_USER_SEQ")]
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [DBColumnReference("EMAIL"), 
        PropertyCaption("El. paštas", 2)]
        public string Email
        {
            get { return m_email; }
            set { m_email = value; }
        }

        [DBColumnReference("USER_NAME"),
        PropertyCaption("Vartotojo vardas", 1)]
        public string UserName
        {
            get { return m_userName; }
            set { m_userName = value; }
        }

        [DBColumnReference("PASSWORD_HASH")]
        public string PasswordHash
        {
            get { return m_passwordHash; }
            set { m_passwordHash = value; }
        }

        [DBColumnReference("SP_ADMIN"),
        PropertyCaption("Administratorius", 3)]
        public bool AdminSp
        {
            get { return m_admin; }
            set { m_admin = value; }
        }

        [DBColumnReference("TEMP_PASS"),
        PropertyCaption("Laikinas slaptažodis", 4)]
        public bool TempPass
        {
            get { return m_tempPass; }
            set { m_tempPass = value; }
        }

        [DBColumnReference("BLOCKED"),
        PropertyCaption("Blokuotas", 5)]
        public bool Blocked
        {
            get { return m_blocked; }
            set { m_blocked = value; }
        }

    }
}