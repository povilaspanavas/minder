using Core.DB;
using Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.Model;

public partial class Pages_RestorePasswordForm : System.Web.UI.Page
{
    string m_hashCode = null;
    private User m_user = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        m_hashCode = Request["hashcode"].Replace("'", string.Empty);
        ApplyHashCode();
        SetEvents();
    }

    private void ApplyHashCode()
    {
        List<RestorePasswordHash> hashs = GenericDbHelper.Get<RestorePasswordHash>(string.Format("HASH_CODE = '{0}'", m_hashCode));
        if (hashs.Count == 0)
            Response.Redirect("~/Default.aspx");
        else if (hashs.Count == 1)
        {
            if (hashs[0].DateTo > DateTime.Now)
                m_user = GenericDbHelper.GetById<User>(hashs[0].UserId);
            else
                Response.Redirect("~/Default.aspx");
        }
    }

    private void SetEvents()
    {
        this.M_OkButton.Click += delegate
        {
            string pass1 = this.M_PassTextBox.Text;
            string pass2 = this.M_Pass2TextBox.Text;

            if (string.IsNullOrEmpty(pass1) || string.IsNullOrEmpty(pass2))
            {
                this.M_LogLabel.Text = "Laukai privalo būti užpildyti!";
                return;
            }

            if (pass1.Equals(pass2) == false)
            {
                this.M_LogLabel.Text = "Slaptažodžiai nesutampa!";
                return;
            }

            m_user.PasswordHash = MD5Generator.CreateMD5Hash(pass1);
            GenericDbHelper.UpdateAndFlush(m_user);
            GenericDbHelper.RunDirectSql(string.Format("DELETE FROM SP_RESTORE_PASS where HASH_CODE = '{0}'", m_hashCode));
            Response.Redirect("~/Default.aspx");
        };
    }
}