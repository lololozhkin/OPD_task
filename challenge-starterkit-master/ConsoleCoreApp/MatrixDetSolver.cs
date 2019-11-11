using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleCoreApp
{
    class MatrixDetSolver
    {
        public static string GetAns(string input)
        {
            input = input.Replace("\\\\", "&").Replace('&', ' ').Replace("   ", " ");
            var stringInput = input.Split(' ');
            //*
            string s;
            string[] str;
            decimal det = 1;
            const decimal EPS = 1e-9m;
            int n = (int)Math.Sqrt(stringInput.Length); ;
            decimal[][] a = new decimal[n][];
            decimal[][] b = new decimal[1][];
            b[0] = new decimal[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = new decimal[n];
                for (int j = 0; j < n; j++)
                {
                    a[i][j] = decimal.Parse(stringInput[i * n + j]);
                }
            }
            for (int i = 0; i < n; ++i)
            {
                int k = i;
                for (int j = i + 1; j < n; ++j)
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
                for (int j = i + 1; j < n; ++j)
                    a[i][j] /= a[i][i];
                for (int j = 0; j < n; ++j)
                    if ((j != i) && (Math.Abs(a[j][i]) > EPS))
                        for (k = i + 1; k < n; ++k)
                            a[j][k] -= a[i][k] * a[j][i];
            }

            return ((long)(Math.Round(det))).ToString();
            //*/
        }
    }
}