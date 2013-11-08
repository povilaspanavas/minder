using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;

namespace XAFSkelbimaiPrograma.RuleExecutor.Rules
{
    public class RuleBlockLicence : IRule
    {
        public void Execute()
        {
            Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING };
            XPClassInfo licencesClass = session.GetClassInfo(typeof(SKUserLicense));
            ICollection licences = session.GetObjects(licencesClass, null, null, 0, 0, false, true);
            List<SKUserLicense> licencesList = licences.Cast<SKUserLicense>().ToList();

            foreach (SKUserLicense licence in licencesList)
            {
                if (licence.Blocked)
                    continue;

                if (licence.DateFrom > DateTime.Now || licence.DateTo < DateTime.Now)
                {
                    licence.Blocked = true;
                    licence.Save();
                }
            }

            session.Disconnect();
            session.Dispose();
        }
    }
}
