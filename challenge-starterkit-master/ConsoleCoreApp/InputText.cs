using System;
using System.IO;
using System.Text;

namespace ConsoleCoreApp
{
    public static class InputText
    {
        public static string GetText()
        {
            /*
             Скачай себе локально тхт и вставь свой путь!!!!
             */
            StreamReader t = new StreamReader("PreparedText.txt");
            var currentLine = new StringBuilder();
            currentLine.Append(t.ReadLine());
            //Console.WriteLine(currentLine.ToString());
            return currentLine.ToString();
        }
    }
}
