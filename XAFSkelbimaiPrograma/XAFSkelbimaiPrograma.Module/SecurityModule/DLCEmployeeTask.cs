using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using XAFSkelbimaiPrograma.Module.SecurityModule;

namespace PUVWeb_TEST.Module.DLCSecuritySystem
{
    [DefaultClassOptions, ImageName("BO_Task")]
    [ListViewFilter("Visi darbai", "")]
    [ListViewFilter("Mano darbai", "[Owner.Oid] = CurrentUserId()")]
    public class DLCEmployeeTask : DevExpress.Persistent.BaseImpl.Task
    {
        public DLCEmployeeTask(Session session)
            : base(session) { }

        private DLCEmployee owner;
        [Association("Employee-Task")]
        public DLCEmployee Owner
        {
            get { return owner; }
            set { SetPropertyValue("Owner", ref owner, value); }
        }
    }
}
