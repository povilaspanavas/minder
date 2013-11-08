using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;
using XAFSkelbimaiPrograma.RuleExecutor.Rules;

namespace XAFSkelbimaiPrograma.RuleExecutor.Executor
{
    class RuleExecutor
    {
        public void RunRules()
        {
            Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING };
            XPClassInfo rulesClass = session.GetClassInfo(typeof(SKRule));
            ICollection rules = session.GetObjects(rulesClass, null, null, 0, 0, false, true);
            List<SKRule> rulesList = rules.Cast<SKRule>().ToList();

            foreach (SKRule rule in rulesList)
            {
                string path = rule.RuleNameSpace;
                DateTime startDate = rule.RunTime;
                DateTime lastRunDate = rule.LastRunTime;
                string typeUniqueCode = rule.RuleType.UniqueCode;
                try
                {
                    bool executed = Execute(path, startDate, lastRunDate, typeUniqueCode);
                    if (executed)
                    {
                        rule.LastRunTime = DateTime.Now;
                        rule.Save();
                    }
                }
                catch
                {}
                
            }

            session.Disconnect();
            session.Dispose();
           
        }

        private bool Execute(string path, DateTime startDate, DateTime lastRunDate, string uniqueCode)
        {
            if (startDate > DateTime.Now)
                return false;

            bool run = false;

            if (uniqueCode.Equals(StaticData.RULE_TYPE_HOUR) && lastRunDate < DateTime.Now.AddHours(-1))
                run = true;
            if (uniqueCode.Equals(StaticData.RULE_TYPE_ONE) && lastRunDate == DateTime.MinValue)
                run = true;
            if (uniqueCode.Equals(StaticData.RULE_TYPE_DAY) && lastRunDate < DateTime.Now.AddHours(-24))
                run = true;

            if (run == false)
                return run;

            Type type = Type.GetType(path);
            object instance = Activator.CreateInstance(type);
            MethodInfo theMethod = type.GetMethod("Execute");
            theMethod.Invoke(instance, null);
            return run;
        }
    }
}
