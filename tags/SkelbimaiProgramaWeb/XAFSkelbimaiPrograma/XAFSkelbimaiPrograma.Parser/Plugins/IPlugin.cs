using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAFSkelbimaiPrograma.Parser.Plugins
{
    public interface IPlugin
    {
         string UniqueCode { get; }
         List<AdvertDto> Parse(string url);
         List<string> TestLinks { get; }
    }
}
