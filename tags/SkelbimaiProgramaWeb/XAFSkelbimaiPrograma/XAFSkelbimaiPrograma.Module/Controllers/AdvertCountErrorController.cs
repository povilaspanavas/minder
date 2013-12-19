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
using DevExpress.Utils.OAuth.Provider;
using DevExpress.ExpressApp.Web;

namespace XAFSkelbimaiPrograma.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class AdvertCountErrorController : ViewController
    {
        public AdvertCountErrorController()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Views (via the TargetXXX properties) and create their Actions.
            //this.TargetViewId = "SKAdvertRead_ListView";
            this.TargetObjectType = typeof(SKAdvert);
            this.TargetViewType = ViewType.ListView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            ListView listView = View as ListView;
            int count = listView.CollectionSource.GetCount();
            if (count > 300)
                MessageBox.Show(Application, "Turim� skelbim� kiekis jau didesnis nei 300! Pra�ome i�trinti skelbimus.",
                       new Action(delegate
                       {

                       }),
                       new Action(delegate
                       {

                       }));
            if (count > 0 && this.TargetViewId.Equals("SKAdvertNew_ListView"))
                WebApplication.Redirect("#ShortcutViewID=SKAdvertNew_ListView&ShortcutObjectClassName=XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects.SKAdvert&PlayBeep=true");
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
