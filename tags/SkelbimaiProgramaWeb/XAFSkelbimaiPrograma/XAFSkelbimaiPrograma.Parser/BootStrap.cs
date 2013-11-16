using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using XAFSkelbimaiPrograma.Parser.Helpers;
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
            for (int i = 0; i < 10; i++)
            {
                ConsoleHelper.WriteLineWithTime("Starting parse service...");
                DateTime startTime = DateTime.Now;
                new AdvertParseService().RunService();
                DateTime endTime = DateTime.Now;
                TimeSpan span = endTime - startTime;

                ConsoleHelper.WriteLineWithTime(string.Format("Parse service end work in {0} seconds", span.TotalSeconds));
                Thread.Sleep(15 * 1000);
            }
        }

    }
}
