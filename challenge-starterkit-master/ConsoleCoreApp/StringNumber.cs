using System;

namespace ConsoleCoreApp
{
    public static class StringNumber
    {
        public static string GetNumber(string input)
        {
            var result = 0L;
            var currentCombination = 0;
            foreach (var word in input.Split())
            {
                var currentDigit = HandleWord(word);
                (result, currentCombination) = UpdateNumber(result, currentCombination, currentDigit);
            }

            result += currentCombination;
            return result.ToString();
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
                "million" => (long) 1e6,
                "billion" => (long) 1e9,
                _ => 0
            };
        }

        private static Tuple<long,int> UpdateNumber(long currentNumber, int currentCombination, long newDigit)
        {
            if (newDigit == 100)
            {
                currentCombination *= (int) newDigit;
            }
            else if (newDigit > 100)
            {
                currentNumber += currentCombination * newDigit;
                currentCombination = 0;
            }
            else
            {
                currentCombination += (int) newDigit;
            }
            return Tuple.Create<long, int>(currentNumber,currentCombination);
        }
    }
}