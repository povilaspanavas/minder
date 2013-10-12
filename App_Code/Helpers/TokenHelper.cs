using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Model;
using Core.Helper;
using System.Text;

/// <summary>
/// Summary description for TokenHelper
/// </summary>
namespace WebSite.Helpers
{
    public class TokenHelper
    {
        private static Random m_random = new Random((int)DateTime.Now.Ticks);

        //Gal reiktų čia į duombazę perkelti, o ne naudoti statinį dictionary
        public TokenHelper()
        {
           
        }

        public Token RegisterToken(int userId)
        {
            Token existToken;
            StaticData.Tokens.TryGetValue(userId, out existToken);
            if (existToken != null && existToken.DateTo > DateTime.Now)
                existToken.DateTo = DateTime.Now.AddHours(StaticData.TOKEN_EXPIRE_AFTER_HOURS);
            else
            {
                StaticData.Tokens.Remove(userId);
                string tokenValue = MD5Generator.CreateMD5Hash(string.Format("{0}", GetRandomString()));
                existToken = new Token(userId, tokenValue, DateTime.Now.AddHours(StaticData.TOKEN_EXPIRE_AFTER_HOURS));
                StaticData.Tokens.Add(userId, existToken);
            }

            return existToken;
        }

        //Public for auto pass generation and temp pass restore
        public string GetRandomString()
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < 12; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * m_random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public Token CheckToken(string tokenValue)
        {
            foreach (Token token in StaticData.Tokens.Values)
            {
                if (token.TokenValue.Equals(tokenValue) && token.DateTo > DateTime.Now)
                {
                    token.DateTo = DateTime.Now.AddHours(StaticData.TOKEN_EXPIRE_AFTER_HOURS);
                    return token;
                }
            }

            return null;
        }

        public void UnRegisterToken(string tokenValue)
        {
            foreach (Token token in StaticData.Tokens.Values)
            {
                if (token.TokenValue.Equals(tokenValue))
                    token.DateTo = DateTime.Now.AddHours(-72);
            }
        }

        public Token ValidateTokenOnFormOpen(System.Web.UI.Page page)
        {
            string tokenValue = string.Empty;
            if (string.IsNullOrEmpty(page.Request["token"]))
            {
                page.Response.Redirect("~/Default.aspx");
            }

            tokenValue = page.Request["token"].Replace("'", string.Empty);
            Token token = CheckToken(tokenValue);
            if (token == null)
                page.Response.Redirect("~/Default.aspx");
            return token;
        }

        public Token GetToken(System.Web.UI.Page page)
        {
            string tokenValue = string.Empty;
            if (string.IsNullOrEmpty(page.Request["token"]))
            {
                return null;
            }

            tokenValue = page.Request["token"].Replace("'", string.Empty);
            Token token = CheckToken(tokenValue);
            return token;
        }
    }
}