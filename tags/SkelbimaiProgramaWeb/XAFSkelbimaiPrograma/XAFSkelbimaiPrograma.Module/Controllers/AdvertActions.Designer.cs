namespace XAFSkelbimaiPrograma.Module.Controllers
{
    partial class AdvertActions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.simpleAction1 = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.simpleAction2 = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // simpleAction1
            // 
            this.simpleAction1.Caption = "Paþymëti kaip perskaitytà";
            this.simpleAction1.ConfirmationMessage = null;
            this.simpleAction1.Id = "ae4dd754-c4af-4890-b382-ddf26a2c6fd1";
            this.simpleAction1.ImageName = null;
            this.simpleAction1.Shortcut = null;
            this.simpleAction1.Tag = null;
            this.simpleAction1.TargetObjectsCriteria = null;
            this.simpleAction1.TargetViewId = "SKAdvertNew_ListView";
            this.simpleAction1.ToolTip = null;
            this.simpleAction1.TypeOfView = typeof(DevExpress.ExpressApp.View);
            this.simpleAction1.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.simpleAction1_Execute);
            // 
            // simpleAction2
            // 
            this.simpleAction2.Caption = "Paþymëti/Atþymëti";
            this.simpleAction2.ConfirmationMessage = null;
            this.simpleAction2.Id = "d07f1c25-e0d2-4b02-a844-4d874d304ece";
            this.simpleAction2.ImageName = null;
            this.simpleAction2.Shortcut = null;
            this.simpleAction2.Tag = null;
            this.simpleAction2.TargetObjectsCriteria = null;
            this.simpleAction2.TargetObjectType = typeof(XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects.SKAdvert);
            this.simpleAction2.TargetViewId = null;
            this.simpleAction2.ToolTip = null;
            this.simpleAction2.TypeOfView = typeof(DevExpress.ExpressApp.View);
            this.simpleAction2.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.simpleAction2_Execute);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction simpleAction1;
        private DevExpress.ExpressApp.Actions.SimpleAction simpleAction2;
    }
}
