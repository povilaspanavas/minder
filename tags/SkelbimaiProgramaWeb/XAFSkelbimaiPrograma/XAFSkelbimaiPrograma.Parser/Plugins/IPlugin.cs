using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAFSkelbimaiPrograma.Parser.Plugins
{
    interface IPlugin
    {
        string UniqueCode { get; }
        void Parse(string url);
        List<string> TestLinks { get; }
    }
}
