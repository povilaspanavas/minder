using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XAFSkelbimaiPrograma.Parser.Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            while (true)
            {
                Process[] proc = Process.GetProcessesByName("XAFSkelbimaiPrograma.Parser");
                if (proc.Length == 0)
                    Process.Start(@"..\..\..\XAFSkelbimaiPrograma.Parser\bin\debug\XAFSkelbimaiPrograma.Parser.exe");
                Thread.Sleep(1000 * 5);
            }
        }
    }
}
