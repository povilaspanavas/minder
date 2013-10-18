using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using XAFSkelbimaiPrograma.Module.SecurityModule;

namespace PUVWeb_TEST.Module.DLCSecuritySystem
{
    [ImageName("BO_Role")]
    public class DLCEmployeeRole : SecuritySystemRole
    {
        public DLCEmployeeRole(Session session)
            : base(session)
        {
        }

        [Association("Employees-EmployeeRoles")]
        public XPCollection<DLCEmployee> Employees
        {
            get
            {
                return GetCollection<DLCEmployee>("Employees");
            }
        }
    }
}
