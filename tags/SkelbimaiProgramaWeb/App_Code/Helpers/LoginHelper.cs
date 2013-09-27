using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Model;
using Core.Helper;
using Core.DB;

/// <summary>
/// Summary description for LoginHelper
/// </summary>
namespace WebSite.Helpers
{
    public class LoginHelper
    {
        public KeyValuePair<LoginStatus, Token> TryLogin(string userName, string plainPassword)
        {
           string passwordHash = MD5Generator.CreateMD5Hash(plainPassword);
           List<User> users = GenericDbHelper.Get<User>(string.Format("USER_NAME = '{0}' and PASSWORD_HASH = '{1}' and BLOCKED = 0", 
               userName, passwordHash));
           if(users.Count != 1)
               return new KeyValuePair<LoginStatus, Token>(LoginStatus.NotLoged, null);
           else if(users[0].AdminSp)
               return new KeyValuePair<LoginStatus, Token>(LoginStatus.LoggedAdmin, new TokenHelper().RegisterToken(users[0].Id));
           else
               return new KeyValuePair<LoginStatus, Token>(LoginStatus.LoggedUser, new TokenHelper().RegisterToken(users[0].Id));
        }

        public void LogOut(string token)
        {
            new TokenHelper().UnRegisterToken(token);
        }
    }

    public enum LoginStatus
    {
        LoggedAdmin,
        LoggedUser,
        NotLoged
    }
}