using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;
using XAFSkelbimaiPrograma.Module.SecurityModule;

namespace XAFSkelbimaiPrograma.Parser.Helpers
{
    class EmailHelper
    {
        private Session m_session;

        public EmailHelper(Session session)
        {
            m_session = session;
        }

        public void SendEmail(List<SKAdvert> adverts)
        {
            if (adverts.Count == 0)
                return;
            DLCEmployee user = m_session.GetObjectByKey<DLCEmployee>(adverts[0].SKUser.Oid);
            string email = user.Email;
            if (string.IsNullOrEmpty(email))
                return;
            string text = FormatEmailText(adverts);
            Send(email, text);
        }

        private string FormatEmailText(List<SKAdvert> adverts)
        {
            string result = string.Empty;

            foreach (SKAdvert advert in adverts)
            {
                result += string.Format("Pavadinimas: {0}{1}", advert.Name, Environment.NewLine);
                result += string.Format("Paieškos nustatymo pavadinimas: {0}{1}", advert.SearchSetting.Name, Environment.NewLine);
                result += string.Format("Radimo data: {0}{1}", advert.FoundDate, Environment.NewLine);
                result += string.Format("Kaina: {0}{1}", advert.Price, Environment.NewLine);
                result += string.Format("Metai: {0}{1}", advert.Year, Environment.NewLine);
                result += string.Format("Kuro tipas: {0}{1}", advert.FuelType, Environment.NewLine);
                result += string.Format("Nuoroda: {0}{1}", advert.Link, Environment.NewLine);

                result += Environment.NewLine;
                result += "-----------------------------------------------------------------------";
                result += Environment.NewLine;
            }


            return result;
        }

        private void Send(string email, string text)
        {
            var fromAddress = new MailAddress("skelbimutikrinimosistema@gmail.com", "Skelbimų tikrinimo sistema");
            var toAddress = new MailAddress(email);
            const string fromPassword = "verbatim258";
           
            string subject = "Nauji skelbimai skelbimų tikrinimo sistemoje!";
            string body = text;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
