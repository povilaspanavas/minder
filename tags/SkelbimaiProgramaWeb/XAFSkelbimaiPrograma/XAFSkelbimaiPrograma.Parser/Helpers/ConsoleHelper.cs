using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFSkelbimaiPrograma.Parser.Helpers
{
    public static class ConsoleHelper
    {
        public static void WriteLineWithTime(string text)
        {
            Console.WriteLine(string.Format("[{0}] {1}", DateTime.Now, text));
        }
    }
}
