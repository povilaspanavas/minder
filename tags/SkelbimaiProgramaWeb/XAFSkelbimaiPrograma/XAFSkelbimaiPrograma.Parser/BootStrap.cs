﻿using System;
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
                DateTime startTime = DateTime.Now;
                new AdvertParseService().RunService();
                DateTime endTime = DateTime.Now;
                TimeSpan span = endTime - startTime;

                Console.WriteLine(string.Format("Parse service end work in {0} seconds", span.TotalSeconds));
                Thread.Sleep(25 * 1000);
            }
        }

    }
}
