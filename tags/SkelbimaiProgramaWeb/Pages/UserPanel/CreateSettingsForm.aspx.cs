using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.Model;
using WebSite.Helpers;
using Core.DB;

public partial class Pages_UserPanel_CreateSettingsForm : System.Web.UI.Page
{
    Token m_token;
    string m_userName;
    string m_update;
    string m_id;
    Settings m_editSettings;

    protected void Page_Load(object sender, EventArgs e)
    {
        m_token = new TokenHelper().ValidateTokenOnFormOpen(this);
        m_userName = Request["username"].Replace("'", string.Empty);
        m_update = Request["update"].Replace("'", string.Empty);
        if(m_update.Equals("true"))
            m_id = Request["id"].Replace("'", string.Empty);
        SetEvents();
        FillDropDown();
        FillFields();
    }

    private void SetEvents()
    {
        this.M_CancelButton.Click += delegate
        {
            Response.Redirect(string.Format("~/Pages/UserPanel/SettingsForm.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName));
        };

        this.M_SaveButton.Click += delegate
        {
            if (string.IsNullOrEmpty(M_NameTextBox.Text) ||
                string.IsNullOrEmpty(M_UrlTextBox.Text))
            {
                this.M_LogLabel.Text = "Visi laukai privalo būti užpildyti!";
                return;
            }

            if (M_UrlTextBox.Text.IndexOf("http") == -1)
            {
                this.M_LogLabel.Text = "Neteisinga nuoroda!";
                return;
            }

            if (m_update.Equals("false"))
            {
                WebSite.Model.User user = GenericDbHelper.Get<User>(string.Format("USER_NAME = '{0}'", m_userName))[0];
                Settings settings = new Settings();
                settings.Name = M_NameTextBox.Text;
                settings.Url = M_UrlTextBox.Text;
                settings.UniqueCode = M_DropDownList.SelectedItem.Text;
                settings.UserId = user.Id;
                GenericDbHelper.SaveAndFlush(settings);
            }
            else
            {
                m_editSettings = GenericDbHelper.GetById<Settings>(Convert.ToInt32(m_id));
                m_editSettings.Name = M_NameTextBox.Text;
                m_editSettings.Url = M_UrlTextBox.Text;
                m_editSettings.UniqueCode = M_DropDownList.SelectedItem.Text;
                GenericDbHelper.UpdateAndFlush(m_editSettings);
            }
            Response.Redirect(string.Format("~/Pages/UserPanel/SettingsForm.aspx?token='{0}'&username='{1}'", m_token.TokenValue, m_userName));
        };

    }

    private void FillDropDown()
    {
        foreach (string uniqueCode in AdvertModel.PluginsUniqueCodes.PluginsUniquecodes)
        {
            this.M_DropDownList.Items.Add(uniqueCode);
        }
        
        
    }

    private void FillFields()
    {
        if (m_update.Equals("false"))
            return;
        if (Page.IsPostBack == false)
        {
            m_editSettings = GenericDbHelper.GetById<Settings>(Convert.ToInt32(m_id));
            this.M_NameTextBox.Text = m_editSettings.Name;
            this.M_UrlTextBox.Text = m_editSettings.Url;
            SetSelectedIndexDropDown(m_editSettings.UniqueCode);
        }
    }

    private void SetSelectedIndexDropDown(string value)
    {
        for (int i = 0; i < this.M_DropDownList.Items.Count; i++)
        {
            if (this.M_DropDownList.Items[i].Text.Equals(value))
                this.M_DropDownList.SelectedIndex = i;
        }
    }
}