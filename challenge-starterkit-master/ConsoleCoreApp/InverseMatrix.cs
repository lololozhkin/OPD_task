using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

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
             //*/
             
            var strDet = MatrixDetSolver.GetAns(input);
            var det = long.Parse(strDet);
            var a = MatrixDetSolver.GetArrayFromTheString(input);
            if (det != 0)
            {
                return TransposeMatrix(1.0M / det, a);
            }
            return "unsolvable";    
            //*/
        }
        
        public static string TransposeMatrix(decimal det, decimal[][] matrix)
        {
            var dimensionMatrix = matrix.GetLength(0);
            var a = new decimal[dimensionMatrix][];
            var answer = new StringBuilder();
            for (var i = 0; i < dimensionMatrix; i++)
            {
                a[i] = new decimal[dimensionMatrix];
            }
            for (var i = 0; i < dimensionMatrix; i++)
            {
                for (var j = 0; j < dimensionMatrix; j++)
                {
                    a[j][i] = matrix[i][j] * det;
                    if (j != dimensionMatrix - 1)
                    {
                        answer.Append(a[j][i].ToString(CultureInfo.InvariantCulture) + " & ");
                    }
                    else if (dimensionMatrix -1 != i)
                    {
                        answer.Append(a[j][i].ToString(CultureInfo.InvariantCulture) + " \\\\ ");
                    }
                    else
                    {
                        answer.Append(a[j][i].ToString(CultureInfo.InvariantCulture));
                    }
                }
            }

            return answer.ToString();
        }
    }
}
