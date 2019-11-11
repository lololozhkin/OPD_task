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
            return task.StartsWith("first") ? GetVejenerAns(task) : GetCeasarAns(task);
        }

        private static string GetVejenerAns(string task)
        {
            task =
                "first longest word=quirrell|7c5zmcp24z7yz7qvyz yywzecze9phd4z7yo4zeyywzspd''y22z97y'yz97q9zvy'3z4q3ze7qkywz7qw4ez5d97z7dlzdwz97y";
            var alphabet = "abcdefghijklmnopqrstuvwxyz0123456789' "
            return string.Empty;
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
