using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleCoreApp
{
    class MatrixDetSolver
    {
        public static decimal[][] GetArrayFromTheString(string input)
        {
            input = input.Replace("\\\\", "&").Replace('&', ' ').Replace("   ", " ");
            var stringInput = input.Split(' ');
            var n = (int)Math.Sqrt(stringInput.Length);
            var a = new decimal[n][];
            for (var i = 0; i < n; i++)
            {
                a[i] = new decimal[n];
                for (var j = 0; j < n; j++)
                {
                    a[i][j] = long.Parse(stringInput[i * n + j]);
                }
            }

            return a;
        }

        public static string GetAns(string input)
        {

            return Determinate.GetAnswer(input);
            /*
            var det = 1.0M;
            const decimal EPS = 1e-9M;
            var a = GetArrayFromTheString(input);
            var n = a.GetLength(0);
            var b = new decimal[1][];
            b[0] = new decimal[n];
            for (var i = 0; i < n; ++i)
            {
                var k = i;
                for (var j = i + 1; j < n; ++j)
                    if (Math.Abs(a[j][i]) > Math.Abs(a[k][i]))
                        k = j;
                if (Math.Abs(a[k][i]) < EPS)
                {
                    det = 0;
                    break;
                }
                b[0] = a[i];
                a[i] = a[k];
                a[k] = b[0];
                if (i != k)
                    det = -det;
                det *= a[i][i];
                for (var j = i + 1; j < n; ++j)
                    a[i][j] /= a[i][i];
                for (var j = 0; j < n; ++j)
                    if ((j != i) && (Math.Abs(a[j][i]) > EPS))
                        for (k = i + 1; k < n; ++k)
                            a[j][k] -= a[i][k] * a[j][i];
            }

            return ((long)(Math.Round(det))).ToString();
            //*/
        }
    }
}