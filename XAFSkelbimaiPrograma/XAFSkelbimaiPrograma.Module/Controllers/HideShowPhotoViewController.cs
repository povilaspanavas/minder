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

namespace XAFSkelbimaiPrograma.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class HideShowPhotoViewController : ViewController
    {
        public HideShowPhotoViewController()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Views (via the TargetXXX properties) and create their Actions.
            this.TargetObjectType = typeof(SKUserSearchSettings);
            this.TargetViewId = "SKUserSearchSettings_DetailView";
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            //foreach (PropertyEditor editor in (view as DetailView).GetItems<PropertyEditor>())
            //{
            //    if (editor.PropertyName == "")
            //    {
            //        //editor.SetReadOnlyByKey("", value);
            //        editor.Caption = "";

            //        //detailView.
            //        (editor.Control as Control).Visible = value;
            //        editor.Refresh();
            //    }
            //}
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
