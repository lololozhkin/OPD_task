using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleCoreApp
{
    public static class InverseMatrix
    {
        public static string GetAnswer(string input)
        {
            /*
             input:
             40 & -8 \\ -100 & 20
             answer:
             unsolvable
             
             
             стоит еще потестить когда нормальный ответ
             */
            input = input.Replace("\\\\", "&").Replace('&', ' ').Replace("   ", " ");
            var stringInput = input.Split(' ');
            //*
            string s;
            string[] str;
            decimal det = 1;
            const decimal EPS = 1e-9m;
            int n = (int)Math.Sqrt(stringInput.Length);
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

            if ((long) (Math.Round(det)) > 1e-7)
            {
                return TransposeMatrix(1 / det, a);
            }
            return "unsolvable";    
            //*/
        }
        
        public static string TransposeMatrix(decimal det, decimal[][] matrix)
        {
            var dimensionMatrix = matrix.GetLength(0);
            decimal[][] a = new decimal[dimensionMatrix][];
            var answer = new StringBuilder();
            for (int i = 0; i < dimensionMatrix; i++)
            {
                for (int j = 0; j < dimensionMatrix; j++)
                {
                    transposeMatrix[j][i] = matrix[i][j] * det;
                    if (j != dimensionMatrix - 1)
                    {
                        answer.Append(transposeMatrix[j][i] + " & ");
                    }
                    else if (dimensionMatrix -1 != i)
                    {
                        answer.Append(transposeMatrix[j][i] + " \\\\\n");
                    }
                    else
                    {
                        answer.Append(transposeMatrix[j][i]);
                    }
                }
            }
            return answer.ToString();
        }
    }
}
