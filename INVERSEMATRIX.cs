using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace ConsoleCoreApp
{

    class InverseMatrix
    {

        public static string GetAnswer(string input)
        {
            var strDet = MatrixDetSolver.GetAns(input);
            var det = long.Parse(strDet);
            var m = MatrixDetSolver.GetArrayFromTheString(input);
            if (det == 0)
            {
                return "unsolvable";
            }
            decimal[][] inv = MatrixInverse(m);

            var dimensionMatrix = inv.Length;
            var answer = new StringBuilder();
            for (int i = 0; i < inv.Length; i++)
            {
                for (int j = 0; j < inv.Length; j++)
                    if (j != dimensionMatrix - 1)
                    {
                        answer.Append(inv[i][j].ToString(CultureInfo.InvariantCulture) + " & ");
                    }
                    else if (dimensionMatrix -1 != i)
                    {
                        answer.Append(inv[i][j].ToString(CultureInfo.InvariantCulture) + " \\\\ ");
                    }
                    else
                    {
                        answer.Append(inv[i][j].ToString(CultureInfo.InvariantCulture));
                    }
            }
            return answer.ToString();

        }

        static decimal[][] MatrixCreate(int rows, int cols)
        {
            decimal[][] result = new decimal[rows][];
            for (int i = 0; i < rows; ++i)
            result[i] = new decimal[cols];
            return result;
        }

        static decimal[][] MatrixIdentity(int n)
        {
            // return an n x n Identity matrix
            decimal[][] result = MatrixCreate(n, n);
            for (int i = 0; i < n; ++i)
            result[i][i] = 1.0M;

            return result;
        }

        static decimal[][] MatrixProduct(decimal[][] matrixA, decimal[][] matrixB)
        {
            int aRows = matrixA.Length; int aCols = matrixA[0].Length;
            int bRows = matrixB.Length; int bCols = matrixB[0].Length;


            decimal[][] result = MatrixCreate(aRows, bCols);

            for (int i = 0; i < aRows; ++i) // each row of A
                for (int j = 0; j < bCols; ++j) // each col of B
                      for (int k = 0; k < aCols; ++k) // could use k less-than bRows
                        result[i][j] += matrixA[i][k] * matrixB[k][j];

            return result;
        }

        static decimal[][] MatrixInverse(decimal[][] matrix)
        {
            int n = matrix.Length;
            decimal[][] result = MatrixDuplicate(matrix);

            int[] perm;
            int toggle;
            decimal[][] lum = MatrixDecompose(matrix, out perm,
              out toggle);


            decimal[] b = new decimal[n];
            for (int i = 0; i < n; ++i)
      {
                for (int j = 0; j < n; ++j)
        {
                    if (i == perm[j])
                        b[j] = 1.0M;
                    else
                        b[j] = 0.0M;
                }

                decimal[] x = HelperSolve(lum, b);

                for (int j = 0; j < n; ++j)
          result[j][i] = x[j];
            }
            return result;
        }

        static decimal[][] MatrixDuplicate(decimal[][] matrix)
        {
            // allocates/creates a duplicate of a matrix.
            decimal[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
            for (int i = 0; i < matrix.Length; ++i) // copy the values
                for (int j = 0; j < matrix[i].Length; ++j)
                    result[i][j] = matrix[i][j];
            return result;
        }

        static decimal[] HelperSolve(decimal[][] luMatrix, decimal[] b)
        {
            // before calling this helper, permute b using the perm array
            // from MatrixDecompose that generated luMatrix
            int n = luMatrix.Length;
            decimal[] x = new decimal[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                decimal sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                decimal sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum / luMatrix[i][i];
            }

            return x;
        }

        static decimal[][] MatrixDecompose(decimal[][] matrix, out int[] perm, out int toggle)
        {
            // Doolittle LUP decomposition with partial pivoting.
            // rerturns: result is L (with 1s on diagonal) and U;
            // perm holds row permutations; toggle is +1 or -1 (even or odd)
            int rows = matrix.Length;
            int cols = matrix[0].Length; // assume square


            int n = rows; // convenience

            decimal[][] result = MatrixDuplicate(matrix);

            perm = new int[n]; // set up row permutation result
            for (int i = 0; i < n; ++i) { perm[i] = i; }

            toggle = 1; // toggle tracks row swaps.
                        // +1 -greater-than even, -1 -greater-than odd. used by MatrixDeterminant

            for (int j = 0; j < n - 1; ++j) // each column
            {
                decimal colMax = Math.Abs(result[j][j]); // find largest val in col
                int pRow = j;
                //for (int i = j + 1; i less-than n; ++i)
                //{
                //  if (result[i][j] greater-than colMax)
                //  {
                //    colMax = result[i][j];
                //    pRow = i;
                //  }
                //}

                // reader Matt V needed this:
                for (int i = j + 1; i < n; ++i)
                {
                    if (Math.Abs(result[i][j]) > colMax)
                    {
                        colMax = Math.Abs(result[i][j]);
                        pRow = i;
                    }
                }
                // Not sure if this approach is needed always, or not.

                if (pRow != j) // if largest value not on pivot, swap rows
                {
                    decimal[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[pRow]; // and swap perm info
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }

                // --------------------------------------------------
                // This part added later (not in original)
                // and replaces the 'return null' below.
                // if there is a 0 on the diagonal, find a good row
                // from i = j+1 down that doesn't have
                // a 0 in column j, and swap that good row with row j
                // --------------------------------------------------

                if (result[j][j] == 0.0M)
                {
                    // find a good row to swap
                    int goodRow = -1;
                    for (int row = j + 1; row < n; ++row)
                    {
                        if (result[row][j] != 0.0M)
                            goodRow = row;
                    }
                    

                    // swap rows so 0.0 no longer on diagonal
                    decimal[] rowPtr = result[goodRow];
                    result[goodRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[goodRow]; // and swap perm info
                    perm[goodRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }
                // --------------------------------------------------
                // if diagonal after swap is zero . .
                //if (Math.Abs(result[j][j]) less-than 1.0E-20) 
                //  return null; // consider a throw

                for (int i = j + 1; i < n; ++i)
                {
                    result[i][j] /= result[j][j];
                    for (int k = j + 1; k < n; ++k)
                    {
                        result[i][k] -= result[i][j] * result[j][k];
                    }
                }


            } // main j column loop

            return result;
        }
    }
}
