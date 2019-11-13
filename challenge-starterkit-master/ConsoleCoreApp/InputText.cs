using System;
using System.IO;
using System.Text;

namespace ConsoleCoreApp
{
    public class Input
    {
        public static string GetText()
        {
            /*
             Скачай себе локально тхт и вставь свой путь!!!!
             */
            StreamReader t = new StreamReader("/home/asd/RiderProjects/TextHarryPotter/preparedText.txt");
            var currentLine = new StringBuilder();
            currentLine.Append(t.ReadLine());
            Console.WriteLine(currentLine.ToString());
            return currentLine.ToString();
        }
    }
}
