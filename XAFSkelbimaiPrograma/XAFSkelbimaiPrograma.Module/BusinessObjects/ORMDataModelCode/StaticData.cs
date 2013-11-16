using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode
{
    public static class StaticData
    {
       // public const string CONNECTION_STRING = "XpoProvider = Firebird; DataSource = 213.197.147.194; User = sysdba; Password = masterkey; Database = XAF_DB; ServerType = 0; Charset = UTF8";
        public const string CONNECTION_STRING = "XpoProvider = Firebird; DataSource = localhost; User = sysdba; Password = masterkey; Database = XAF_DB; ServerType = 0; Charset = UTF8";

        public const string RULE_TYPE_ONE = "OneTime";
        public const string RULE_TYPE_HOUR = "Hour";
        public const string RULE_TYPE_DAY = "Daily";


    }
}
