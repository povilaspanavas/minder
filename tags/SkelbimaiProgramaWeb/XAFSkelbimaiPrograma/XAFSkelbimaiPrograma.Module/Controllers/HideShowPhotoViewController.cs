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
using XAFSkelbimaiPrograma.Module.SecurityModule;
using System.Web.UI;

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
            this.TargetViewId = "Blocked";
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            View.ControlsCreated += new EventHandler(View_ControlsCreated);
            ObjectSpace.ObjectChanged += new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
        }
        protected override void OnDeactivated()
        {
            View.ControlsCreated -= new EventHandler(View_ControlsCreated);
            ObjectSpace.ObjectChanged -= new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
            base.OnDeactivated();
        }
        void View_ControlsCreated(object sender, EventArgs e)
        {
            ((Control)View.Control).PreRender += new EventHandler(ViewController1_PreRender);
            HideControls();
        }
        void ViewController1_PreRender(object sender, EventArgs e)
        {
            ((Control)View.Control).PreRender -= new EventHandler(ViewController1_PreRender);
            //DetailView detailView = (DetailView)View;
            //SetEditorReadOnlyByName(detailView, "MaidenName", ((MyContact)detailView.CurrentObject as MyContact).Gender == Gender.Male);
            HideControls();
        }
        void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            HideControls();
            //DetailView detailView = (DetailView)View;
            //if (e.PropertyName == "Gender")
            //{
            //    SetEditorReadOnlyByName(detailView, "MaidenName", (((DevExpress.ExpressApp.ObjectManipulatingEventArgs)(e)).Object as MyContact).Gender == Gender.Male);
            //}
        }
        //private void SetEditorReadOnlyByName(DetailView detailView, string targetPropertyName, bool value)
        //{
        //    foreach (PropertyEditor editor in detailView.GetItems<PropertyEditor>())
        //    {
        //        if (editor.PropertyName == targetPropertyName)
        //        {
        //            //editor.SetReadOnlyByKey("", value);
        //            (editor.Control as Control).Visible = !value;
        //            editor.Refresh();
        //        }
        //    }
        //}
       
        private void HideControls()
        {
            Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING };
            DLCEmployee employee = session.GetObjectByKey<DLCEmployee>(SecuritySystem.CurrentUserId);

            bool email = false;
            bool photo = false;

            foreach (SKUserLicense licence in employee.Licenses)
            {
                if (licence.Blocked)
                    continue;
                email = licence.LicenseType.Email;
                photo = licence.LicenseType.Photo;
            }
            session.Disconnect();
            session.Dispose();

            foreach (PropertyEditor editor in (this.View as DetailView).GetItems<PropertyEditor>())
            {
                if (editor.PropertyName == "SendEmail")
                {
                    ////editor.SetReadOnlyByKey("", value);
                    //editor.Caption = "";
                    if (editor.Control == null)
                        continue;

                    //detailView.
                    (editor.Control as Control).Visible = email;
                    editor.Refresh();
                }

                if (editor.PropertyName == "LoadPhoto")
                {
                    if (editor.Control == null)
                        continue;
                    ////editor.SetReadOnlyByKey("", value);
                    //editor.Caption = "";

                    //detailView.
                    (editor.Control as Control).Visible = photo;
                    editor.Refresh();
                }
            }
        }
    }
}
