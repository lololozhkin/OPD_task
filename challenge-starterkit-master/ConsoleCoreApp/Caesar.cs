using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace ConsoleCoreApp
{
    public static class Caesar
    {
        public static string GetAns(string task)
        {
            return task.StartsWith("first") ? GetNonCeasarCypherAns(task) : GetCeasarAns(task);
        }

        private static string GetNonCeasarCypherAns(string task)
        {
            if (!TheLargestMatch.IsTextSet())
            {
                TheLargestMatch.Initialize();
            }

            return TheLargestMatch.getAns(task);
        }

        private static string GetCeasarAns(string task)
        {
            var s = "abcdefghijklmnopqrstuvwxyz0123456789' ";
            var words = task.Split('|');
            var t0 = words[0].Split('=');
            var code = -Int32.Parse(t0[1]);
            var d = "";
            foreach (var sym in words[1])
            {
                var i = 0;
                while (s[i] != sym)
                    i++;
                d += s[(i + code + 380) % 38];
            }
            return d;
        }
        
    }
}
