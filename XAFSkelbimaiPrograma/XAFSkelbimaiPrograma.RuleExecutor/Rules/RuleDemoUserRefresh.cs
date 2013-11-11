using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode;
using XAFSkelbimaiPrograma.Module.SecurityModule;

namespace XAFSkelbimaiPrograma.RuleExecutor.Rules
{
    public class RuleDemoUserRefresh : IRule
    {
        public void Execute()
        {
            Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING };
            DLCEmployee demoUser = session.FindObject<DLCEmployee>(CriteriaOperator.Parse("UserName = ?", "demo"));
            session.ExecuteNonQuery(string.Format("delete from \"SKAdvert\" where \"SKUser\" = '{0}'", demoUser.Oid));
            session.ExecuteNonQuery(string.Format("delete from \"SKUserSearchSettings\" where \"SKUser\" = '{0}'", demoUser.Oid));
        }
    }
}
