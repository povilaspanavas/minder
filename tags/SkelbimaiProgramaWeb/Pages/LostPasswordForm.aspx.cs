using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.Helpers;

public partial class Pages_LostPasswordForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetEvents();
    }

    private void SetEvents()
    {
        this.M_OkButton.Click += delegate
        {
            string mail = this.M_EmailTextBox.Text;
            if (string.IsNullOrEmpty(mail))
            {
                this.M_LogLabel.Text = "Nenurodytas el. paštas!";
                return;
            }
            this.M_LogLabel.Text = new RestorePasswordHelper().TryRestore(mail);
        };
    }
}