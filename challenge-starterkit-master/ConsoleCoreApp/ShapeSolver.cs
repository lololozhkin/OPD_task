using System;
using System.Collections.Generic;

namespace ConsoleCoreApp
{
    internal class ShapeSolver
    {
        public static string GetAns(string line)
        {
            var pts = line.Replace("(", "").Replace(")", "").Split(' ');
            var xyu = new List<List<int>>();
            for (int i = 0; i < pts.Length; i++)
            {
                var cur = pts[i].Split(',');
                if (cur.Length > 1)
                {
                    int a;
                    int b;
                    if (Int32.TryParse(cur[0], out a))
                    {
                        if (Int32.TryParse(cur[1], out b))
                        {
                            xyu.Add(new List<int>() { a, b });
                        }
                    }
                }
            }

            int maxX = Int32.MinValue;
            int minX = Int32.MaxValue;
            int maxY = Int32.MinValue;
            int minY = Int32.MaxValue;
            foreach (var sperm in xyu)
            {
                maxX = Math.Max(maxX, sperm[0]);
                minX = Math.Min(minX, sperm[0]);
                maxY = Math.Max(maxY, sperm[1]);
                minY = Math.Min(minY, sperm[1]);
            }

            int maxYminX = Int32.MaxValue;
            int maxYmaxX = Int32.MinValue;
            int minYminX = Int32.MaxValue;
            int minYmaxX = Int32.MinValue;
            foreach (var sperm in xyu)
            {
                if (sperm[1] == maxY)
                {
                    Console.WriteLine(sperm[0]);
                    maxYminX = Math.Min(maxYminX, sperm[0]);
                    maxYmaxX = Math.Max(maxYmaxX, sperm[0]);
                }
                else if (sperm[1] == minY)
                {
                    minYminX = Math.Min(minYminX, sperm[0]);
                    minYmaxX = Math.Max(minYmaxX, sperm[0]);
                }
            }

            var cnt = 0;
            if (maxYmaxX - maxYminX == maxX - minX)
                cnt++;
            if (minYmaxX - minYminX == maxX - minX)
                cnt++;

            if (cnt == 0)
                return "cirle";
            else if (cnt == 1)
                return "equilateraltriangle";
            else
                return "square";
        }
    }
}