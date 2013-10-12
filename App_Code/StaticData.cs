using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Model;

namespace WebSite
{
    /// <summary>
    /// Summary description for StaticData
    /// </summary>
    public static class StaticData
    {
        public const string CORE_CONFIG_PATH = "d:\\Projektai\\SkelbimaiProgramaWeb\\CoreConfig.xml";
        public const string LOG4NET_CONFIG_PATH = "d:\\Projektai\\SkelbimaiProgramaWeb\\log4net.xml";
        public const int TOKEN_EXPIRE_AFTER_HOURS = 1;

        private static Dictionary<int, Token> m_tokens = new Dictionary<int, Token>();

        //Public
        public static Dictionary<int, Token> Tokens { get { return m_tokens; } }

        public static class EmailSettings
        {
            public const string EMAIL = "autogidascheck2@gmail.com";
            public const string PASS = "verbatim963";
            public const string SENDER_NAME = "Skelbimų tikrinimo sistema";
        }
    }
}