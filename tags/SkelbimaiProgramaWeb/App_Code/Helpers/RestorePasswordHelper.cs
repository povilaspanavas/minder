using Core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Model;

namespace WebSite.Helpers
{
    public class RestorePasswordHelper
    {
        public RestorePasswordHelper()
        {
        }

        /// <summary>
        /// Return message for user
        /// </summary>
        public string TryRestore(string mail)
        {
            if (string.IsNullOrEmpty(mail))
                return "Nenurodytas el. paštas!";
            if (mail.IndexOf("@") == -1)
                return "Neteisingas el. paštas!";
            List<User> user = GenericDbHelper.Get<User>(string.Format("EMAIL = '{0}'", mail));
            if (user == null || user.Count == 0)
                return "Su tokiu el. pašto adresu nerastas nei vienas naudotojas!";
            else if(user.Count == 1)
            {
                //TODO IGNO padaryti nuorodas restorinimui
                return "Informacija išsiųsta į nurodytą el. paštą!";
            }
            return "Nenustatyta klaida!";
        }
    }
}