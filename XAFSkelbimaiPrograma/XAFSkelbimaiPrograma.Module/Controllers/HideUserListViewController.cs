using System;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Templates;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Model.NodeGenerators;
using XAFSkelbimaiPrograma.Module.SecurityModule;
using DevExpress.Xpo;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode;
using PUVWeb_TEST.Module.DLCSecuritySystem;

namespace XAFSkelbimaiPrograma.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class HideUserListViewController : ViewController
    {
        public HideUserListViewController()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            using (Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING })
            {
                XPCollection<DLCEmployee> users = new XPCollection<DLCEmployee>(session);
                users.Criteria = CriteriaOperator.Parse("Oid = ?", SecuritySystem.CurrentUserId);

                bool admin = false;
                foreach (DLCEmployeeRole role in users[0].EmployeeRoles)
                {
                    if (role.IsAdministrative)
                    {
                        admin = true;
                        break;
                    }
                }

                if (admin == false)
                {
                    // No, it is not administrator
                    SingleChoiceAction StandardShowNavigationItemAction = Frame.GetController<DevExpress.ExpressApp.SystemModule.ShowNavigationItemController>().ShowNavigationItemAction;
                    for (int i = 0; i < StandardShowNavigationItemAction.Items.Count; i++)
                    {
                        if (StandardShowNavigationItemAction.Items[i].Id == "Default")
                        {
                            StandardShowNavigationItemAction.Items.Remove(StandardShowNavigationItemAction.Items[i]);
                            break;
                        }
                    }
                }
                session.Disconnect();
            }

            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
