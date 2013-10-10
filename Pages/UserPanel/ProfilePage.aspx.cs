using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.Helpers;
using WebSite.Model;

public partial class Pages_UserPanel_ProfilePage : System.Web.UI.Page
{
    private Token m_token = null;
    private string m_userName;
    private User m_user;

    protected void Page_Load(object sender, EventArgs e)
    {
        m_token = new TokenHelper().ValidateTokenOnFormOpen(this);
        m_userName = Request["username"].Replace("'", string.Empty);
    }
}