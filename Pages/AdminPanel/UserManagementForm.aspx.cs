using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.Model;
using WebSite.Helpers;
using System.Data;
using Core.DB;

public partial class Pages_UserManagementForm : System.Web.UI.Page
{
    private Token m_token;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetEvents();
        m_token = new TokenHelper().ValidateTokenOnFormOpen(this);
        Page.Title = "Vartotojų paskyrų tvarkymai";
        SetUrls();
        LoadUserGrid();
    }

    private void SetUrls()
    {
        this.M_AdminPanelLink.NavigateUrl = string.Format("~/Pages/AdminPanel/AdminPanel.aspx?token='{0}'", m_token.TokenValue);
        this.M_UserManagementLink.NavigateUrl = string.Format("~/Pages/AdminPanel/UserManagementForm.aspx?token='{0}'", m_token.TokenValue);
        this.M_LogOutLink.NavigateUrl = string.Format("~/Default.aspx?token='{0}'", m_token.TokenValue);
        this.M_ConnectedUserLink.NavigateUrl = string.Format("~/Pages/AdminPanel/ConnectedUsersForm.aspx?token='{0}'", m_token.TokenValue);
    }

    private void SetEvents()
    {
        this.M_UserGridView.RowDataBound += delegate(object sender, GridViewRowEventArgs e)
        {
            GridViewRowEventArgs ep = e as GridViewRowEventArgs;

            if (ep.Row.DataItem != null)
            {
                LinkButton lb = new LinkButton();
                lb.CommandArgument = ep.Row.Cells[0].Text;
                lb.CommandName = "change";
                lb.Text = "Redaguoti ";

                LinkButton lb1 = new LinkButton();
                lb1.CommandArgument = ep.Row.Cells[0].Text;
                lb1.CommandName = "remove";
                lb1.Text = "Trinti ";

                ep.Row.Cells[ep.Row.Cells.Count - 1].Controls.Add((Control)lb);
                ep.Row.Cells[ep.Row.Cells.Count - 1].Controls.Add((Control)lb1);
            }
        };

        this.M_UserGridView.RowCommand += delegate(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Equals("remove"))
            {
                string arg = e.CommandArgument.ToString();
                if (arg.Equals("admin"))
                    return;
                GenericDbHelper.RunDirectSql(string.Format("DELETE FROM SP_USER where USER_NAME = '{0}'", arg));
                Response.Redirect(string.Format("~/Pages/AdminPanel/UserManagementForm.aspx?token='{0}'", m_token.TokenValue));
            }

            if (e.CommandName.ToLower().Equals("change"))
            {
                string arg = e.CommandArgument.ToString();
                Response.Redirect(string.Format("~/Pages/AdminPanel/NewUserForm.aspx?token='{0}'&update='true'&username='{1}'", m_token.TokenValue, arg));
            }
        };

        this.M_CreateUserButton.Click += delegate
        {
            Response.Redirect(string.Format("~/Pages/AdminPanel/NewUserForm.aspx?token='{0}'&update='false'", m_token.TokenValue));
        };
    }

    private void LoadUserGrid()
    {
        List<User> allUsers = GenericDbHelper.Get<User>();
        DataTable source = new GridViewHelper().ConvertObjectListToDataTable<User>(allUsers);
        this.M_UserGridView.DataSource = source;
        this.DataBind();
    }
}