using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.Helpers;
using WebSite.Model;

public partial class Pages_AdminPanel : System.Web.UI.Page
{
    private Token m_token = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetEvents();
        m_token = new TokenHelper().ValidateTokenOnFormOpen(this);
    }

    private void SetEvents()
    {
        this.M_UserManagementLink.Click += delegate
        {
            Response.Redirect(string.Format("~/Pages/AdminPanel/UserManagementForm.aspx?token='{0}'", m_token.TokenValue));
        };

        this.M_LogOutLink.Click += delegate
        {
            new LoginHelper().LogOut(m_token.TokenValue);
            Response.Redirect(string.Format("~/Default.aspx"));
        };

        this.M_ConnectedUserLink.Click += delegate
        {
            Response.Redirect(string.Format("~/Pages/AdminPanel/ConnectedUsersForm.aspx?token='{0}'", m_token.TokenValue));
        };
    }
}