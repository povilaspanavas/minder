using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;

namespace XAFSkelbimaiPrograma.Parser.Helpers
{
    class LogDBHelper
    {
        public void Log(Exception e, SKUserSearchSettings settings, LogType logType)
        {
            string message = FormatMessage(e, settings);
            Session session = new Session { ConnectionString = StaticData.CONNECTION_STRING };
            SKParserLog logObj = new SKParserLog(session);
            logObj.Message = message;
            logObj.LogDate = DateTime.Now;
            logObj.LogType = logType.ToString();
            logObj.Save();
            session.Disconnect();
            session.Dispose();
        }

        private string FormatMessage(Exception e, SKUserSearchSettings settings)
        {
            if (settings == null)
                return string.Format("Exception: {0}", e);
            else
                return string.Format("Exception: {0}{1} In: {2} via {3}", e,
                    Environment.NewLine, settings.Url, settings.Plugin.Name);
        }
    }

    public enum LogType
    {
        ParserError,
        FatalError,
        Info,
        Debug
    }
}
