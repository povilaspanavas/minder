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
        Page.Title = "Administravimo panelė";
        m_token = new TokenHelper().ValidateTokenOnFormOpen(this);
        SetUrls();
        SetEvents();
    }

    private void SetEvents()
    {
        //this.M_LogOutLink.Click
        // Čia reikia atstatyti į LinkButtonus ir viskas bus gerai.
    }

    private void SetUrls()
    {
        this.M_AdminPanelLink.NavigateUrl = string.Format("~/Pages/AdminPanel/AdminPanel.aspx?token='{0}'", m_token.TokenValue);
        this.M_UserManagementLink.NavigateUrl = string.Format("~/Pages/AdminPanel/UserManagementForm.aspx?token='{0}'", m_token.TokenValue);
        this.M_LogOutLink.NavigateUrl = string.Format("~/Default.aspx?token='{0}'", m_token.TokenValue);
        this.M_ConnectedUserLink.NavigateUrl = string.Format("~/Pages/AdminPanel/ConnectedUsersForm.aspx?token='{0}'", m_token.TokenValue);
    }
}