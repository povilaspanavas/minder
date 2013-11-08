using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XAFSkelbimaiPrograma.RuleExecutor
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Execute rules...");
                new RuleExecutor.Executor.RuleExecutor().RunRules();
                Console.WriteLine("Rules executed.");
                Thread.Sleep(60 * 1000 * 50);
            }
        }
    }
}
