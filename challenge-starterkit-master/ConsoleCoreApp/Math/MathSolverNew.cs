using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace ConsoleCoreApp
{
    class MathSolver
    {
        public static string GetAnswer(string input)
        {
            StreamWriter sw = new StreamWriter(@"D:\Trash\Downloads\challenge-starterkit-master228\challenge-starterkit-master\ConsoleCoreApp\Math\in.txt");
            sw.Write(input);
            sw.Close();

            Thread.Sleep(5000);
            
            StreamReader sr = new StreamReader(@"D:\Trash\Downloads\challenge-starterkit-master228\challenge-starterkit-master\ConsoleCoreApp\Math\out.txt");
            var ans = sr.ReadLine();
            sr.Close();
            
            return ans;
        }
    }
}
