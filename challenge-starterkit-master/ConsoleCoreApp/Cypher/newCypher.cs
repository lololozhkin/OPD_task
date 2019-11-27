using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCoreApp
{
    public static class NewCypher
    {
        private static string text = InputText.GetText();

        public static string GetAns(string task)
        {
            var toFind = task.Split('|')[1];
            for (var left = 0; left < text.Length - toFind.Length; left++)
            {
                var toCompare = text.Substring(left, toFind.Length);
                var buf = new Dictionary<char, HashSet<char>>();
                for (var i = 0; i < toFind.Length; i++)
                {
                    if (!buf.ContainsKey(toFind[i]))
                    {
                        buf[toFind[i]] = new HashSet<char>();
                    }

                    buf[toFind[i]].Add(toCompare[i]);
                }

                if (buf.All(pair => pair.Value.Count == 1))
                {
                    return toCompare;
                }
            }

            return "Я люблю Ивана Домашних!";
        }
    }
}
