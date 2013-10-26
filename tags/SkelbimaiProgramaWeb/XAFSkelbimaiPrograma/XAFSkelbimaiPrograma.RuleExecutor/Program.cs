using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFSkelbimaiPrograma.RuleExecutor
{
    class Program
    {
        static void Main(string[] args)
        {
            new RuleExecutor.Executor.RuleExecutor().RunRules();
        }
    }
}
