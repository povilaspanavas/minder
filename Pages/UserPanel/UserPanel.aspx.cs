using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.Model;
using WebSite.Helpers;
using Core.DB;
using System.Data;

public partial class Pages_UserPanel : System.Web.UI.Page
{
    private Token m_token = null;
    private string m_userName;
    private User m_user;

    protected void Page_Load(object sender, EventArgs e)
    {
        m_token = new TokenHelper().ValidateTokenOnFormOpen(this);
        m_userName = Request["username"].Replace("'", string.Empty);
        SetEvents();
        CheckTempPass();
        //StartService();
        LoadGrid();
    }

    private void SetEvents()
    {
        this.M_SettingsLink.Click += delegate
        {
            Response.Redirect(string.Format("~/Pages/UserPanel/SettingsForm.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName));
        };

        this.M_LogOutLink.Click += delegate
        {
            new LoginHelper().LogOut(m_token.TokenValue);
            Response.Redirect(string.Format("~/Default.aspx"));
        };
    }

    private void CheckTempPass()
    {
        m_user = GenericDbHelper.Get<User>(string.Format("USER_NAME = '{0}'", m_userName))[0];
        if (m_user.TempPass)
            Response.Redirect(string.Format("~/Pages/UserPanel/TempPassForm.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName));
    }

    private void LoadGrid()
    {
        DataTable table = new DataTable();
        table.Columns.Add("Pavadinimas");
        table.Columns.Add("Radimo data");

        object[] values = new object[table.Columns.Count];
        values[0] = "Paskdjasdasd";
        values[1] = DateTime.Now;

        table.Rows.Add(values);

        this.M_AdvertGrid.DataSource = table;
        this.M_AdvertGrid.DataBind();

    }

    private void StartService()
    {
       // if (Page.IsPostBack == false)
       // {
           // new AdvertServiceHelper(m_user.Id).Run();
       // }
    }
}