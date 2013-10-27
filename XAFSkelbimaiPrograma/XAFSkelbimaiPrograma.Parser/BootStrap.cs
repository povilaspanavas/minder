using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using XAFSkelbimaiPrograma.Parser.Services;
//using DevExpress.Data.Filtering;
//using DevExpress.Xpo;
//using DevExpress.Xpo.Metadata;
//using XAFSkelbimaiPrograma.Module;
//using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;

namespace XAFSkelbimaiPrograma.Parser
{
    class BootStrap
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Starting parse service...");
                new AdvertParseService().RunService();
                Console.WriteLine("Parse service end work.");
                Thread.Sleep(10 * 1000);
            }
        }

    }
}
