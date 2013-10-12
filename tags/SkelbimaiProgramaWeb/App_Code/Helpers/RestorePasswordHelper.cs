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
            else if (user.Count == 1)
            {
                AddTokenToRestoreAndSendMail(user[0]);
                return "Informacija išsiųsta į nurodytą el. paštą!";
            }
            return "Nenustatyta klaida!";
        }

        private void AddTokenToRestoreAndSendMail(User user)
        {
            string randomString = new TokenHelper().GetRandomString();
            GenericDbHelper.RunDirectSql("DELETE FROM SP_RESTORE_PASS WHERE USER_ID = " + user.Id);
            RestorePasswordHash newHash = new RestorePasswordHash();
            newHash.UserId = user.Id;
            newHash.DateTo = DateTime.Now.AddHours(1);
            newHash.HashCode = randomString;
            GenericDbHelper.SaveAndFlush(newHash);

            //Send mail
            string mailText =
            string.Format(
@"
Sveiki, 

Norėdami iš naujo nustatyti slaptažodį paspauskite šią nuorodą: {0}
Nuoroda galioja iki {1}.
", GenerateLink(randomString), newHash.DateTo.ToString());

            string subject = "Slaptažodio priminimas!";
            new MailSendHelper().Send(user.Email, subject, mailText);
        }

        private string GenerateLink(string hashCode)
        {
            return string.Format("http://localhost:50108/SkelbimaiProgramaWeb/Pages/RestorePasswordForm.aspx?hashcode='{0}'", hashCode);
        }
    }
}