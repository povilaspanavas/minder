using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace XAFSkelbimaiPrograma.Module.Controllers
{
    
        [NonPersistent]
        public class MessageBox
        {
            private string message;
            public string Message { get { return message; } }
            private MessageBox(string message)
            {
                this.message = message;
            }
            public static void Show(XafApplication app, ShowViewParameters svp, string message, Action okMethod, Action cancelMethod)
            {
                IObjectSpace os = ObjectSpaceInMemory.CreateNew();
                MessageBox obj = new MessageBox(message);
                svp.CreatedView = app.CreateDetailView(os, obj);
                DialogController dc = app.CreateController<DialogController>();
                
                //dc.Accepting += new EventHandler<DialogControllerAcceptingEventArgs>(delegate
                //{
                //    if (okMethod != null) okMethod();
                //});
                //dc.Cancelling += new EventHandler(delegate
                //{
                //    if (cancelMethod != null) cancelMethod();
                //});
                svp.Controllers.Add(dc);
                svp.Context = TemplateContext.PopupWindow;
                svp.TargetWindow = TargetWindow.NewModalWindow;
                svp.NewWindowTarget = NewWindowTarget.Separate;
            }
            public static void Show(XafApplication app, string message, Action okMethod, Action cancelMethod)
            {
                ShowViewParameters svp = new ShowViewParameters();
                Show(app, svp, message, okMethod, cancelMethod);
                app.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            }
        }
}
