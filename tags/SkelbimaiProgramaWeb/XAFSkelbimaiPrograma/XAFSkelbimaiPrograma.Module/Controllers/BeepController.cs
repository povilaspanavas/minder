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
using DevExpress.ExpressApp.Web;
using DevExpress.Xpo;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;
using System.Collections;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode;

namespace XAFSkelbimaiPrograma.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class BeepController : ViewController<ListView>
    {
        public BeepController()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Views (via the TargetXXX properties) and create their Actions.
            this.TargetViewId = "SKAdvertNew_ListView";
        }

        //protected override void OnActivated()
        //{
        //    base.OnActivated();
        //    // Perform various tasks depending on the target View.
        //    base.OnActivated();
        //    // Perform various tasks depending on the target View.
        //    ListView listView = View as ListView;
        //    int count = listView.CollectionSource.GetCount();

        //    if (count > 0 && this.TargetViewId.Equals("SKAdvertNew_ListView"))
        //    {
        //        XPCollection<SKAdvert> adverts = listView.CollectionSource as XPCollection<SKAdvert>;
        //        //WebApplication.Redirect("#ShortcutViewID=SKAdvertNew_ListView&ShortcutObjectClassName=XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects.SKAdvert&PlayBeep=true");
        //    }
        //        //else
        //    //    WebApplication.Redirect("#ShortcutViewID=SKAdvertNew_ListView&ShortcutObjectClassName=XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects.SKAdvert");
        //}

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        //protected override void OnDeactivated()
        //{
        //    // Unsubscribe from previously subscribed events and release other references and resources.
        //    base.OnDeactivated();
        //}

        protected override void OnActivated()
        {
            base.OnActivated();
            bool needSound = false;
            using (Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING })
            {
                //XPCollection<SKAdvert> adverts = session.GetObjects()

                XPCollection<SKAdvert> adverts =
                new XPCollection<SKAdvert>(session,
                    CriteriaOperator.Parse(string.Format("SKUser.Oid = '{0}' AND Read = False AND Deleted = False", SecuritySystem.CurrentUserId)),
                    null);

                foreach (SKAdvert advert in adverts)
                {
                    if (advert.PlayedSound == false)
                    {
                        advert.PlayedSound = true;
                        needSound = true;
                        advert.Save();
                    }
                }

                if(needSound)
                    WebApplication.Redirect("Default.aspx?PlayBeep=true");
            }
            
        }
       
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
}
