using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.Model;
using WebSite.Helpers;
using Core.Helper;
using Core.DB;

public partial class Pages_AdminPanel_NewUserForm : System.Web.UI.Page
{
    private Token m_token;
    private bool m_update;
    private string m_userName;
    private User m_user = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        m_token = new TokenHelper().ValidateTokenOnFormOpen(this);
        Page.Title = "Naujas vartotojas";
        SetUrls();

        string update = Request["update"].Replace("'", string.Empty);
        if (update.Equals("true"))
            m_update = true;

        if (m_update)
            m_userName = Request["username"].Replace("'", string.Empty);

        SetEvents();

        PrepareForm();


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
        this.M_GeneratePassButton.Click += delegate
        {
            string pass = new TokenHelper().GetRandomString();
            this.M_PassTextBox.Text = pass;
            this.M_TempPassCheckBox.Checked = true;
        };

        this.M_SaveButton.Click += delegate
        {
            if (m_update == false)
            {
                if (string.IsNullOrEmpty(M_UserNameTextBox.Text) ||
                    string.IsNullOrEmpty(M_EmailTextBox.Text) ||
                    string.IsNullOrEmpty(M_TempPassCheckBox.Text))
                {
                    M_LogLabel.Text = "Ne visi laukai užpildyti!";
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(M_UserNameTextBox.Text) ||
                    string.IsNullOrEmpty(M_EmailTextBox.Text))
                {
                    M_LogLabel.Text = "Ne visi laukai užpildyti!";
                    return;
                }
            }

            if (m_update == false)
            {
                List<User> users = GenericDbHelper.Get<User>(string.Format("USER_NAME = '{0}'", M_UserNameTextBox.Text));
                if (users.Count != 0)
                {
                    M_LogLabel.Text = "Toks vartotojo vardas jau yra!";
                    return;
                }
            }

            WebSite.Model.User user;
            if (m_update == false)
                user = new User();
            else
                user = m_user;

            user.UserName = M_UserNameTextBox.Text;
            user.TempPass = M_TempPassCheckBox.Checked;
            user.Email = M_EmailTextBox.Text;
            if (string.IsNullOrEmpty(M_PassTextBox.Text) == false)
                user.PasswordHash = MD5Generator.CreateMD5Hash(M_PassTextBox.Text);
            user.Blocked = M_BlockedCheckBox.Checked;

            if (m_update == false)
                GenericDbHelper.SaveAndFlush(user);
            else
                GenericDbHelper.UpdateAndFlush(user);


            Response.Redirect(string.Format("~/Pages/AdminPanel/UserManagementForm.aspx?token='{0}'",
                m_token.TokenValue));
        };

        this.M_CancelButton.Click += delegate
        {
            Response.Redirect(string.Format("~/Pages/AdminPanel/UserManagementForm.aspx?token='{0}'",
                m_token.TokenValue));
        };
    }

    private void PrepareForm()
    {
        if (Page.IsPostBack == false)
            this.M_TempPassCheckBox.Checked = true;

        if (m_update == true)
        {
            //Fill fields
            List<User> users = GenericDbHelper.Get<User>(string.Format("USER_NAME = '{0}'", m_userName));

            if (Page.IsPostBack == false)
            {
                this.M_UserNameTextBox.Enabled = false;
                this.M_UserNameTextBox.Text = m_userName;
                this.M_BlockedCheckBox.Checked = users[0].Blocked;
                this.M_EmailTextBox.Text = users[0].Email;
                this.M_TempPassCheckBox.Checked = users[0].TempPass;
            }

            m_user = users[0];
        }
    }
}