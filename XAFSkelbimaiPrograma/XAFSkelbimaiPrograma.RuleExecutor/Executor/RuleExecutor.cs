using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XAFSkelbimaiPrograma.RuleExecutor.Rules;

namespace XAFSkelbimaiPrograma.RuleExecutor.Executor
{
    class RuleExecutor
    {
        public void RunRules()
        {
            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(IRule))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IRule;

            foreach (IRule rule in instances)
            {
                rule.Execute();
            }
        }
    }
}
