using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace XAFSkelbimaiPrograma.Module.Helpers
{
    public class ConfigHelper
    {
        private static string m_connectionString = null;

        public string GetConnectionString()
        {
            try
            {
                if (m_connectionString != null)
                    return m_connectionString;

                string path = HttpContext.Current.Server.MapPath("/Web.config");
                string allFile = File.ReadAllText(path);
                string[] splited = Regex.Split(allFile, "<add name=\"ConnectionString\" connectionString=\"");
                string[] splited2 = Regex.Split(splited[1], "\"");

                m_connectionString = splited2[0];
                return splited2[0];
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
