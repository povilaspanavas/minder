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
using AdvertModel;

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

        this.M_AdvertGrid.RowDataBound += delegate(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false; //ID
            e.Row.Cells[6].Visible = false; //Link url
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
        List<Advert> allAdverts = GenericDbHelper.Get<Advert>(string.Format("USER_ID = {0}", m_user.Id));
        DataTable table = new GridViewHelper().ConvertObjectListToDataTable<Advert>(allAdverts);
        //Pridedamas checkboxas
        DataColumn coll = table.Columns.Add("Select", Type.GetType("System.Boolean"));
        coll.SetOrdinal(1);

        this.M_AdvertGrid.DataSource = table;
        this.M_AdvertGrid.DataBind();

        foreach (GridViewRow row in M_AdvertGrid.Rows)
        {
            CheckBox check = row.Cells[1].Controls[0] as CheckBox;
            check.Enabled = true;
        }
    }

    private void StartService()
    {
       // if (Page.IsPostBack == false)
       // {
           // new AdvertServiceHelper(m_user.Id).Run();
       // }
    }
}