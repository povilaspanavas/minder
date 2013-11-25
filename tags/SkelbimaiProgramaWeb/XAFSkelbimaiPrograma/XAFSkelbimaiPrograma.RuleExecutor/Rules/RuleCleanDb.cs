using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode;

namespace XAFSkelbimaiPrograma.RuleExecutor.Rules
{
    class RuleCleanDb : IRule
    {
        public void Execute()
        {
            Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING };
            List<string> queries = GetQueries();

            foreach (string query in queries)
            {
                session.ExecuteNonQuery(query);
            }
            session.Disconnect();
            session.Dispose();
        }

        private List<string> GetQueries()
        {
            List<string> result = new List<string>();
            string queryLog = "delete FROM \"SKParserLog\" where \"GCRecord\" is not null";

            DateTime dateMonthMinus = DateTime.Now.AddMonths(-1);
            string queryAdvert = string.Format("delete FROM \"SKAdvert\" where \"FoundDate\" < '{0}' and \"Deleted\" = 1 and \"Mark\" = 0", dateMonthMinus);
            string querySettings = "delete FROM \"SKUserSearchSettings\" where \"GCRecord\" is not null and \"Oid\" not in (select a.\"SearchSetting\" from \"SKAdvert\" a)";

            result.Add(queryLog);
            result.Add(queryAdvert);
            result.Add(querySettings);

            return result;

        }
    }
}
