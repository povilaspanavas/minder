using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.Model;
using WebSite.Helpers;
using WebSite;
using System.Data;
using Core.DB;

public partial class Pages_AdminPanel_ConnectedUsersForm : System.Web.UI.Page
{
    Token m_token;

    protected void Page_Load(object sender, EventArgs e)
    {
        m_token = new TokenHelper().ValidateTokenOnFormOpen(this);
        Page.Title = "Prisijungę vartotojai";
        SetUrls();
        LoadGrid();
    }

    private void SetUrls()
    {
        this.M_AdminPanelLink.NavigateUrl = string.Format("~/Pages/AdminPanel/AdminPanel.aspx?token='{0}'", m_token.TokenValue);
        this.M_UserManagementLink.NavigateUrl = string.Format("~/Pages/AdminPanel/UserManagementForm.aspx?token='{0}'", m_token.TokenValue);
        this.M_LogOutLink.NavigateUrl = string.Format("~/Default.aspx?token='{0}'", m_token.TokenValue);
        this.M_ConnectedUserLink.NavigateUrl = string.Format("~/Pages/AdminPanel/ConnectedUsersForm.aspx?token='{0}'", m_token.TokenValue);
    }

    private void LoadGrid()
    {
        if (Page.IsPostBack == true)
            return;
        DataTable table = new DataTable();
        table.Columns.Add("Vartotojo vardas");
        table.Columns.Add("Token");
        table.Columns.Add("Galioja iki");

        foreach (int id in StaticData.Tokens.Keys)
        {
            object[] values = new object[table.Columns.Count];
            Token token = StaticData.Tokens[id];
            if (token.DateTo <= DateTime.Now) //Pasibaigusių nerodom
                continue;

            WebSite.Model.User user = GenericDbHelper.GetById<User>(token.UserId);

            values[0] = user.UserName;
            values[1] = token.TokenValue;
            values[2] = token.DateTo;

            table.Rows.Add(values);
            
        }

        M_UserGridView.DataSource = table;
        M_UserGridView.DataBind();
    }
}