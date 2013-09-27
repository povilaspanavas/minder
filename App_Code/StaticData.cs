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

        //Modules UniqueCodes
       // public const string AUTOGIDAS = "Autogidas.lt";
        //public const string AUTOPLIUS = "Autoplius.lt";
    }
}