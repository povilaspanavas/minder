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
using DevExpress.ExpressApp.Web.SystemModule;
using DevExpress.Xpo;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode;
using DevExpress.Xpo.Metadata;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;
using System.Collections;
using DevExpress.ExpressApp.DC;
using XAFSkelbimaiPrograma.Module.SecurityModule;

namespace XAFSkelbimaiPrograma.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class SKUserSettingsController : WebNewObjectViewController
    {
        public SKUserSettingsController()
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

        protected override void New(SingleChoiceActionExecuteEventArgs args)
        {
            Type typeInf = args.SelectedChoiceActionItem.Data as Type;

            if (typeInf.FullName.Equals(typeof(SKUserSearchSettings).FullName) == false)
            {
                base.New(args);
                return;
            }

            if (AllowCreate())
                base.New(args);
            else
            {
                MessageBox.Show(Application, "Daugiau kurti nuorodø negalite!",
                   new Action(delegate
                   {

                   }),
                   new Action(delegate
                   {

                   }));
            }
        }

        private bool AllowCreate()
        {
            //Èia reikia pagal licencijos tipà leisti arba neleisti kurti
            using (Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING })
            {
                XPClassInfo settingsClass = session.GetClassInfo(typeof(SKUserSearchSettings));
                XPClassInfo licenceClass = session.GetClassInfo(typeof(SKUserLicense));
                ICollection settings = session.GetObjects(settingsClass, CriteriaOperator.Parse(string.Format("SKUser.Oid = '{0}'", SecuritySystem.CurrentUserId)), null, 0, 0, false, true);
                // DLCEmployee user = session.GetObjectByKey<DLCEmployee>(SecuritySystem.CurrentUserId);
                ICollection licences = session.GetObjects(licenceClass, CriteriaOperator.Parse(string.Format("SKUser.Oid = '{0}' AND (Blocked = false or Blocked = null)", SecuritySystem.CurrentUserId)), null, 0, 0, false, true);
                List<SKUserLicense> licencesList = licences.Cast<SKUserLicense>().ToList();
                List<SKUserSearchSettings> settingsList = settings.Cast<SKUserSearchSettings>().ToList();
                bool result = true;
                if (licencesList.Count != 1)
                    result = false;

                if (result == true && licencesList[0].LicenseType.UrlLinkCount > settingsList.Count)
                    result = true;
                else
                    result = false;

                session.Disconnect();
                return result;
            }

        }

    }
}
