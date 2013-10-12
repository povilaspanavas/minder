using Core.Tools.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MailSendHelper
/// </summary>
namespace WebSite.Helpers
{
    public class MailSendHelper
    {
        public MailSendHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void Send(string email, string subject, string mailText)
        {
            MailSender sender = new MailSender();
            sender.FromMail = StaticData.EmailSettings.EMAIL;
            sender.FromMailPass = StaticData.EmailSettings.PASS;
            sender.SenderName = StaticData.EmailSettings.SENDER_NAME;

            sender.SendMail(subject, mailText, email);
        }
    }
}