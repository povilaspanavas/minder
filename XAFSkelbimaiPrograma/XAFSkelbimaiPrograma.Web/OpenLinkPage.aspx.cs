using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XAFSkelbimaiPrograma.Web
{
    public partial class OpenLinkPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string link = Request["linkId"].Replace("sklink", "&");
            Response.Write("<script Language=JavaScript>");
            Response.Write("window.open('" + link + "','_blank')");
            Response.Write("</script> ");
            //Response.End();
            Response.Write("<SCRIPT Language=JavaScript>history.go(-1)</SCRIPT>");
            Response.End();
        }
    }
}