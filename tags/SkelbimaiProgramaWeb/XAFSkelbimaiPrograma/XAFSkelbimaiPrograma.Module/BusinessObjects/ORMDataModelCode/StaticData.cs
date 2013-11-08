using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode
{
    public static class StaticData
    {
        public const string CONNECTION_STRING = "XpoProvider = Firebird; DataSource = localhost; User = sysdba; Password = masterkey; Database = XAF_DB; ServerType = 0; Charset = UTF8";

        //public static string[] PluginsUniqueCodes = new string[] 
        //{ 
        //  "Autogidas.lt", 
        //  "Autoplius.lt",
        //  "Plius.lt", 
        //  "Skelbiu.lt",
        //  "Auto24.ee",
        //  "Blocket.se",
        //  "Mobile.de",
        //  "Marktplaats.nl",
        //  "Finn.no",
        //  "Gaspedaal.nl",
        //  "Speurders.nl",
        //  "Otomoto.pl",
        //  "Allegro.pl",
        //  "Leboncoin.fr",
        //  "Donedeal.ie",
        //  "Autotrader.co.uk"
        //};

        public const string RULE_TYPE_ONE = "OneTime";
        public const string RULE_TYPE_HOUR = "Hour";
        public const string RULE_TYPE_DAY = "Daily";


    }
}
