using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XAFSkelbimaiPrograma.Parser.Helpers;

namespace XAFSkelbimaiPrograma.Parser.Plugins
{
    public interface IPlugin
    {
         string UniqueCode { get; }
         List<AdvertDto> Parse(string url, UserParseInfoDto info);
         List<string> TestLinks { get; }
    }
}
