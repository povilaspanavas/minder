using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.DB;
using WebSite.Model;
using AdvertModel;

public partial class Pages_DbVersions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //GenericDbHelper.DropAllTables();
       // GenericDbHelper.CreateTable(typeof(User));

        //Create first User
       // WebSite.Model.User adminUser = new User();
        //adminUser.Email = "ign.bgd@gmail.com";
       // adminUser.AdminSp = true;
       // adminUser.UserName = "admin";
        //adminUser.PasswordHash = "abe6db4c9f5484fae8d79f2e868a673c".ToUpper(); //Masterkey

      //  GenericDbHelper.SaveAndFlush(adminUser);

        //----
        //Settings table
       // GenericDbHelper.CreateTable(typeof(Settings));

        //-----
        //Advert table
       // GenericDbHelper.CreateTable(typeof(Advert));
    }
}