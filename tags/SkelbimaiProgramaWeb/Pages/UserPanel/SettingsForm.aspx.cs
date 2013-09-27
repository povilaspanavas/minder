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

public partial class Pages_UserPanel_SettingsForm : System.Web.UI.Page
{
    private Token m_token = null;
    private string m_userName;
    private User m_user;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetEvents();
        m_token = new TokenHelper().ValidateTokenOnFormOpen(this);
        m_userName = Request["username"].Replace("'", string.Empty);
        LoadGrid();
    }

    private void LoadGrid()
    {
        m_user = GenericDbHelper.Get<User>(string.Format("USER_NAME = '{0}'", m_userName))[0];
        List<Settings> settings = GenericDbHelper.Get<Settings>("USER_ID = " + m_user.Id);
        DataTable table = new GridViewHelper().ConvertObjectListToDataTable<Settings>(settings);
        this.M_SettingsGrid.DataSource = table;
        this.M_SettingsGrid.DataBind();
    }

    private void SetEvents()
    {
        this.M_SettingsGrid.RowDataBound += delegate (object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
        };

        this.M_CreateSettingsButton.Click += delegate
        {
            Response.Redirect(string.Format("~/Pages/UserPanel/CreateSettingsForm.aspx?token='{0}'&update='false'&username='{1}'", m_token.TokenValue, m_userName));
        };

        this.M_UserPanelLink.Click += delegate
        {
            Response.Redirect(string.Format("~/Pages/UserPanel/UserPanel.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName));
        };

        this.M_SettingsGrid.RowDataBound += delegate(object sender, GridViewRowEventArgs e)
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

        this.M_SettingsGrid.RowCommand += delegate(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Equals("remove"))
            {
                string id = e.CommandArgument.ToString();

                GenericDbHelper.RunDirectSql(string.Format("DELETE FROM SP_SETTINGS where ID = {0}", id));
                Response.Redirect(string.Format("~/Pages/UserPanel/SettingsForm.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName));
            }

            if (e.CommandName.ToLower().Equals("change"))
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect(string.Format("~/Pages/UserPanel/CreateSettingsForm.aspx?token='{0}'&update='true'&username='{1}'&id='{2}'", m_token.TokenValue, m_userName, id));
            }
        };
    }

   
}