using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Security;
using System.Text;

namespace ConsoleCoreApp
{
    public static class TheLargestMatch
    {
        private static string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789' ";
        private static string text = string.Empty;

        public static bool IsTextSet()
        {
            return text != string.Empty;
        }

        public static void Initialize()
        {
            text = InputText.GetText();
        }

        public static string getAns(string task)
        {
            var parts = task.Split('|')
        }
        private static string GetAnswer(string text, string toFind, string key)
        {
            toFind = GetPreparedString(toFind, key);
            var answer = string.Empty;
            var max = 0;
            for (var i = 0; i < text.Length - toFind.Length; i++)
            {
                var matchValue = 0;
                for (var j = 0; j < toFind.Length; j++)
                {
                    matchValue += toFind[j] == text[i + j] ? 1 : 0;
                }

                if (max < matchValue)
                {
                    max = matchValue;
                    answer = text.Substring(i, toFind.Length);
                }
            }

            return answer;
        }

        private static string GetPreparedString(string toFind, string key)
        {
            var spaceShift = (alphabet.IndexOf(' ') - alphabet.IndexOf(GetMostFrequentSymbol(toFind)) + 380) % 38;
            var builder = new StringBuilder(toFind);
            for (var i = 0; i < builder.Length; i++)
            {
                builder[i] = alphabet[(alphabet.IndexOf(builder[i]) + spaceShift) % 38];
            }
            var lettersShift = new int[alphabet.Length];
            Initialize(lettersShift, -1);

            var firstLongestWord = GetFirstLongestWord(builder.ToString());
            for (var i = 0; i < firstLongestWord.Length; i++)
            {
                lettersShift[alphabet.IndexOf(firstLongestWord[i])] =
                    (alphabet.IndexOf(key[i]) - alphabet.IndexOf(firstLongestWord[i]) + 380) % 38;
            }

            ShiftedReplace(builder, lettersShift);
            return builder.ToString();
        }

        private static void ShiftedReplace(StringBuilder builder, int[] lettersShift)
        {
            for (var i = 0; i < builder.Length; i++)
            {
                if (builder[i] == ' ')
                {
                    continue;
                }
                if (lettersShift[alphabet.IndexOf(builder[i])] != -1)
                {
                    builder[i] =
                        alphabet[(alphabet.IndexOf(builder[i]) + lettersShift[alphabet.IndexOf(builder[i])]) % 38];
                }
                else
                {
                    builder[i] = '?';
                }
            }
        }

        private static void Initialize(int[] array, int value)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }

        private static char GetMostFrequentSymbol(string text)
        {
            var count = new int[alphabet.Length];
            var max = 0;
            var ans = '?';
            foreach (var symbol in text)
            {
                var index = alphabet.IndexOf(symbol);
                count[index]++;
                if (count[index] > max)
                {
                    max = count[index];
                    ans = alphabet[index];
                }
            }

            return ans;
        }

        private static string GetFirstLongestWord(string text)
        {
            var words = text.Split(' ');
            var ans = string.Empty;
            var max = 0;

            foreach (var word in words)
            {
                if (word.Length > max)
                {
                    max = word.Length;
                    ans = word;
                }
            }

            return ans;
        }
    }
}
