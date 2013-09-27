using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.Model;
using WebSite.Helpers;
using Core.DB;
using Core.Helper;

public partial class Pages_UserPanel_TempPassForm : System.Web.UI.Page
{
    private Token m_token = null;
    private string m_userName;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetEvents();
        m_token = new TokenHelper().ValidateTokenOnFormOpen(this);
        m_userName = Request["username"].Replace("'", string.Empty);
    }

    private void SetEvents()
    {
        this.M_OkButton.Click += delegate
        {
            string pass1 = this.M_Pass1TextBox.Text;
            string pass2 = this.M_Pass2TextBox.Text;

            if (pass1.Equals(pass2) && string.IsNullOrEmpty(pass1) == false && string.IsNullOrEmpty(pass2) == false)
            {
                WebSite.Model.User user = GenericDbHelper.Get<User>(string.Format("USER_NAME = '{0}'", m_userName))[0];
                user.TempPass = false;
                user.PasswordHash = MD5Generator.CreateMD5Hash(pass1);

                GenericDbHelper.UpdateAndFlush(user);
                Response.Redirect(string.Format("~/Pages/UserPanel/UserPanel.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName));
            }
            else
            {
                this.M_LogLabel.Text = "Slaptažodžiai nesutampa!";
            }
        };
    }
}