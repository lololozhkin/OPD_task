using System;
using System.Collections.Generic;

namespace ConsoleCoreApp
{
    public static class StringNumber
    {
        public static string StringToNumber(string input)
        {
            input = input.Replace('-', ' ');
            var words = input.Split();
            var numbers = new List<long>();
            var signs = new List<string>();
            var index = 0;
            while (index < words.Length)
            {
                var tuple = GetNumber(index, words);
                var number = tuple.Item1;
                if (tuple.Item2 - index > 0)
                    numbers.Add(number);
                if (tuple.Item2 < words.Length)
                    signs.Add(words[tuple.Item2]);
                index = tuple.Item2 + 1;
            }

            return GetResult(numbers, signs).ToString();
        }

        private static long HandleWord(string word)
        {
            return word switch
            {
                "zero" => 0,
                "one" => 1,
                "two" => 2,
                "three" => 3,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "seven" => 7,
                "eight" => 8,
                "nine" => 9,
                "ten" => 10,
                "eleven" => 11,
                "twelve" => 12,
                "thirteen" => 13,
                "fourteen" => 14,
                "fifteen" => 15,
                "sixteen" => 16,
                "seventeen" => 17,
                "eighteen" => 18,
                "nineteen" => 19,
                "twenty" => 20,
                "thirty" => 30,
                "forty" => 40,
                "fifty" => 50,
                "sixty" => 60,
                "seventy" => 70,
                "eighty" => 80,
                "ninety" => 90,
                "hundred" => 100,
                "thousand" => 1000,
                "million" => (long)1e6,
                "billion" => (long)1e9,
                _ => -1
            };
        }

        private static Tuple<long, int> UpdateNumber(long currentNumber, int currentCombination, long newDigit)
        {
            if (newDigit == 100)
            {
                currentCombination *= (int)newDigit;
            }
            else if (newDigit > 100)
            {
                currentNumber += currentCombination * newDigit;
                currentCombination = 0;
            }
            else
            {
                currentCombination += (int)newDigit;
            }
            return Tuple.Create<long, int>(currentNumber, currentCombination);
        }

        private static Tuple<long, int> GetNumber(int startIndex, string[] words)
        {
            var result = 0L;
            var currentCombination = 0;
            var index = startIndex;
            while (index < words.Length)
            {
                var currentDigit = HandleWord(words[index]);
                if (currentDigit == -1)
                {
                    break;
                }
                (result, currentCombination) = UpdateNumber(result, currentCombination, currentDigit);
                index++;
            }

            result += currentCombination;
            return Tuple.Create(result, index);
        }

        private static long GetResult(List<long> numbers, List<string> signs)
        {
            var result = numbers[0];
            var numberIndex = 1;
            foreach (var sign in signs)
            {
                switch (sign)
                {
                    case "plus":
                        result += numbers[numberIndex];
                        numberIndex++;
                        break;
                    case "times":
                        result *= numbers[numberIndex];
                        numberIndex++;
                        break;
                    case "minus":
                        result -= numbers[numberIndex];
                        numberIndex++;
                        break;
                    case "squared":
                        result *= result;
                        break;
                    case "sqared":
                        result *= result;
                        break;
                    case "twice":
                        result *= 2;
                        break;
                    case "thrice":
                        result *= 3;
                        break;
                    case "cubed":
                        result *= result * result;
                        break;
                    default:
                        throw new Exception("undefined sign " + sign);
                }
            }

            return result;
        }
    }
}