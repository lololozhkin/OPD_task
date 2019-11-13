using System;
using System.Collections.Generic;

namespace ConsoleCoreApp
{
    public class ShapeSolver
    {
        public static string GetAnswer(string line)
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
                            xyu.Add(new List<int>() {a, b});
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

            int maxXmaxY = Int32.MinValue;
            int maxXminY = Int32.MaxValue;
            int minXmaxY = Int32.MinValue;
            int minXminY = Int32.MaxValue;
            int maxYmaxX = Int32.MinValue;
            int maxYminX = Int32.MaxValue;
            int minYmaxX = Int32.MinValue;
            int minYminX = Int32.MaxValue;

            foreach (var sperm in xyu)
            {
                if (sperm[0] == maxX)
                {
                    maxXmaxY = Math.Max(maxXmaxY, sperm[1]);
                    maxXminY = Math.Min(maxXminY, sperm[1]);
                }

                if (sperm[0] == minX)
                {
                    minXmaxY = Math.Max(minXmaxY, sperm[1]);
                    minXminY = Math.Min(minXminY, sperm[1]);
                }

                if (sperm[1] == maxY)
                {
                    maxYminX = Math.Min(maxYminX, sperm[0]);
                    maxYmaxX = Math.Max(maxYmaxX, sperm[0]);
                }

                if (sperm[1] == minY)
                {
                    minYminX = Math.Min(minYminX, sperm[0]);
                    minYmaxX = Math.Max(minYmaxX, sperm[0]);
                }
            }

            /*Console.WriteLine(maxX + " " + maxXminY);
            Console.WriteLine(maxX + " " + maxXmaxY);
            Console.WriteLine(maxY + " " + maxYmaxX);
            Console.WriteLine(maxY + " " + maxYminX);
            Console.WriteLine(minX + " " + minXmaxY);
            Console.WriteLine(minX + " " + minXminY);
            Console.WriteLine(minY + " " + minYminX);
            Console.WriteLine(minY + " " + minYmaxX);*/

            int lineA = minY - maxXminY;
            int lineB = maxX - minYmaxX;
            int lineC = minYmaxX * maxXminY - maxX * minY;

            /*Console.WriteLine(lineA);
            Console.WriteLine(lineB);
            Console.WriteLine(lineC);*/

            if (lineA != 0 || lineB != 0)
            {
                foreach (var sperm in xyu)
                {
                    if ((double) (lineA * sperm[0] + lineB * sperm[1] + lineC) / Math.Sqrt(Sqr(lineA) + Sqr(lineB)) <
                        -5)
                    {
                        /*Console.WriteLine(lineA * sperm[0] + lineB * sperm[1] + lineC);
                        Console.WriteLine(5 * (Sqr(lineA) + Sqr(lineB)));
                        Console.WriteLine(sperm[0] + " " + sperm[1]);
                        Console.WriteLine("oo");*/
                        return "ellipse";
                    }
                }
            }

            int cheat = 10;
            if (Math.Abs(Sqr(maxXmaxY - maxXminY) - Sqr(minXmaxY - minXminY)) > cheat ||
                Math.Abs(Sqr(maxYmaxX - maxYminX) - Sqr(minYmaxX - minYminX)) > cheat ||
                Math.Abs(Sqr(maxX - minYmaxX) + Sqr(maxXminY - minY) - Sqr(minX - maxYminX) - Sqr(minXmaxY - maxY)) >
                cheat ||
                Math.Abs(Sqr(minX - maxYminX) + Sqr(minXmaxY - maxY) - Sqr(maxX - minYmaxX) - Sqr(maxXminY - minY)) >
                cheat)
            {
                return "triangle";
            }

            return "rectangle";
        }
        
        public static int Sqr(int d)
        {
            return d * d;
        }

    }
}
