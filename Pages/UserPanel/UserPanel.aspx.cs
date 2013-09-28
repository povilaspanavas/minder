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
using System.Text.RegularExpressions;

public partial class Pages_UserPanel : System.Web.UI.Page
{
    private Token m_token = null;
    private string m_userName;
    private User m_user;

    //Indexex in grid
    int m_indexId = 0;
    int m_indexRead = 1;
    int m_indexSelectCheckBox = 2;
    int m_indexUrl = 9;

    protected void Page_Load(object sender, EventArgs e)
    {
        m_token = new TokenHelper().ValidateTokenOnFormOpen(this);
        m_userName = Request["username"].Replace("'", string.Empty);

        SetEvents();
        CheckTempPass();
        LoadGrid();


        //Refresh kas 10 s.
        Response.Expires = 0;
        Response.Buffer = true;
        Response.Clear();
        Response.AddHeader("Refresh", "20");
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
            e.Row.Cells[m_indexId].Visible = false; //ID
            e.Row.Cells[m_indexRead].Visible = false; //read
            e.Row.Cells[m_indexUrl].Visible = false; //Link url
        };

        this.M_DeleteButton.Click += delegate
        {
            foreach (GridViewRow row in M_AdvertGrid.Rows)
            {
                CheckBox checkBox = row.Cells[m_indexSelectCheckBox].Controls[0] as CheckBox;
                if (checkBox.Checked)
                {
                    int id = Convert.ToInt32(row.Cells[m_indexId].Text);
                    GenericDbHelper.RunDirectSql("update sp_advert set deleted = 1 where id = " + id);
                }
            }
            Response.Redirect(string.Format("~/Pages/UserPanel/UserPanel.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName));
        };

        this.M_MarkAsReadButton.Click += delegate
        {
            foreach (GridViewRow row in M_AdvertGrid.Rows)
            {
                CheckBox checkBox = row.Cells[m_indexSelectCheckBox].Controls[0] as CheckBox;
                if (checkBox.Checked)
                {
                    int id = Convert.ToInt32(row.Cells[m_indexId].Text);
                    bool read = Convert.ToBoolean(row.Cells[m_indexRead].Text);
                    if (read == false)
                        GenericDbHelper.RunDirectSql("update sp_advert set read = 1 where id = " + id);
                }
            }
            Response.Redirect(string.Format("~/Pages/UserPanel/UserPanel.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName));
        };

        this.M_SelectAllButton.Click += delegate
        {
            foreach (GridViewRow row in M_AdvertGrid.Rows)
            {
                CheckBox checkBox = row.Cells[m_indexSelectCheckBox].Controls[0] as CheckBox;
                checkBox.Checked = true;
            }
        };

        this.M_RefreshButton.Click += delegate
        {
            Response.Redirect(string.Format("~/Pages/UserPanel/UserPanel.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName));
        };

        this.M_OpenLinkButton.Click += delegate
        {
            foreach (GridViewRow row in M_AdvertGrid.Rows)
            {
                CheckBox checkBox = row.Cells[m_indexSelectCheckBox].Controls[0] as CheckBox;
                if (checkBox.Checked)
                {
                    string url = row.Cells[m_indexUrl].Text;
                    Response.Write("<script>");
                    Response.Write(string.Format("window.open('{0}','_blank')", url));
                    Response.Write("</script>");
                    if (row.Cells[m_indexRead].Text.Equals("False"))
                        GenericDbHelper.RunDirectSql("update sp_advert set read = 1 where id = " + row.Cells[m_indexId].Text);
                    checkBox.Checked = false;
                }
            }
            Response.Write("<script>");
            Response.Write(string.Format(string.Format("window.location=\"{0}\"", string.Format("UserPanel.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName))));
            Response.Write("</script>");
            Response.Flush();
            //Response.Redirect(string.Format("~/Pages/UserPanel/UserPanel.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName));
        };

        //this.M_AdvertGrid.RowCommand += delegate(object sender, GridViewCommandEventArgs e)
        //{
        // if (e.CommandName.ToLower().Equals("openlink"))
        //  {
        //   string[] args = Regex.Split(e.CommandArgument.ToString(), ";separator;");
        //   string url = args[0];

        //        Response.Write("<script>");
        //        Response.Write(string.Format("window.open('{0}','_blank')", url));
        //        Response.Write("</script>");

        //        GenericDbHelper.RunDirectSql("update sp_advert set read = 1 where id = "+args[1]);
        //    }
        ////};
    }

    private void CheckTempPass()
    {
        m_user = GenericDbHelper.Get<User>(string.Format("USER_NAME = '{0}'", m_userName))[0];
        if (m_user.TempPass)
            Response.Redirect(string.Format("~/Pages/UserPanel/TempPassForm.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName));
    }

    private void LoadGrid()
    {
        if (Page.IsPostBack == true)
            return;

        List<Advert> allAdverts = GenericDbHelper.Get<Advert>(string.Format("USER_ID = {0} and DELETED = 0", m_user.Id));
        allAdverts = allAdverts.OrderByDescending(M => M.DateA).ToList();
        DataTable table = new GridViewHelper().ConvertObjectListToDataTable<Advert>(allAdverts);
        table.Columns.RemoveAt(table.Columns.Count - 1);//Remove komandos column
        //Pridedamas checkboxas
        DataColumn coll = table.Columns.Add("Žymėti", Type.GetType("System.Boolean"));
        coll.SetOrdinal(m_indexSelectCheckBox);

        this.M_AdvertGrid.DataSource = table;
        this.M_AdvertGrid.DataBind();

        foreach (GridViewRow row in M_AdvertGrid.Rows)
        {
            CheckBox check = row.Cells[m_indexSelectCheckBox].Controls[0] as CheckBox;
            check.Enabled = true;

            bool read = Convert.ToBoolean(row.Cells[m_indexRead].Text);
            if (read == false)
                row.Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");

            //int? id = row.Cells[0].Text as int?;
        }
    }
}