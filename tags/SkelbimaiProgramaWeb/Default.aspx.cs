using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;
using log4net;
using System.IO;
using WebSite.Model;
using Core.DB;
using Core.Helper;
using WebSite.Helpers;

public partial class _Default : System.Web.UI.Page
{
    ILog m_log = LogManager.GetLogger(typeof(_Default));
    private Token m_token = null;

    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "Login";
        m_token = new TokenHelper().GetToken(this);
        if (m_token != null)
            new LoginHelper().LogOut(m_token.TokenValue);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadConfig();
        SetEvents();
        this.LoginLabel.Visible = false;
    }

    private void SetEvents()
    {
        this.LoginButton.Click += delegate
        {
            string userName = this.UsernameTextBox.Text;
            string plainPassword = this.PasswordTextBox.Text;

           KeyValuePair<WebSite.Helpers.LoginStatus, Token> result = new LoginHelper().TryLogin(userName, plainPassword);
           if(result.Key == WebSite.Helpers.LoginStatus.LoggedAdmin)
               Response.Redirect(string.Format("~/Pages/AdminPanel/AdminPanel.aspx?token='{0}'", result.Value.TokenValue));
           if (result.Key == WebSite.Helpers.LoginStatus.LoggedUser)
               Response.Redirect(string.Format("~/Pages/UserPanel/UserPanel.aspx?token='{0}'&username='{1}'", result.Value.TokenValue, userName));
           if (result.Key == WebSite.Helpers.LoginStatus.NotLoged)
           {
               this.LoginLabel.Visible = true;
               this.LogLabel.Text = "Nepavyko prisijungti!";
           }
        };
    }
    

    private void LoadConfig()
    {
        ConfigLoader.Load(WebSite.StaticData.CORE_CONFIG_PATH);
        FileInfo config = new FileInfo(WebSite.StaticData.LOG4NET_CONFIG_PATH);
        log4net.Config.XmlConfigurator.Configure(config);

        m_log.Info("Config Loaded!");
    }
}