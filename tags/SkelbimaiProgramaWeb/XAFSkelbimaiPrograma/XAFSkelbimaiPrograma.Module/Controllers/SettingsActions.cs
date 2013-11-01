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
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;
using DevExpress.Xpo;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode;
using DevExpress.ExpressApp.Web;

namespace XAFSkelbimaiPrograma.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class SettingsActions : ViewController
    {
        public SettingsActions()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
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

        private void simpleAction1_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var selectedObjects = e.SelectedObjects;
            using (Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING })
            {

                session.BeginTransaction();
                foreach (object obj in selectedObjects)
                {
                    SKUserSearchSettings settings = obj as SKUserSearchSettings;
                    if (settings == null)
                        continue;


                    settings = session.GetObjectByKey<SKUserSearchSettings>(settings.Oid);

                    //Process.Start(advert.Link);
                    //WebApplication.Redirect(string.Format("<script>window.location({0}, '_blank');</script>", advert.Link));
                    WebApplication.Redirect(string.Format("OpenLinkPage.aspx?linkId={0}", settings.Url));
                    //ASPxHyperLink link = new ASPxHyperLink();
                    //link.NavigateUrl = advert.Link;
                    //link.
                    //Launcher.LaunchUriAsync();


                }

                session.CommitTransaction();
                this.View.ObjectSpace.CommitChanges();
                this.View.ObjectSpace.Refresh();
                this.View.Refresh();
                session.Disconnect();
            }
        }
    }
}
