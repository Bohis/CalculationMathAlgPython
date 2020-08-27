using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public static class Langrandg
    {
        public static double[,] MethodLangr(double[,] X, double[,] Y, double[,] newX)
        {

            double?[,] matrixMem = new double?[X.GetLength(0), X.GetLength(0)];
            double[,] D = new double[X.GetLength(0),1];
            double[,] L = new double[X.GetLength(0),1];
            double[,] newY = new double[newX.GetLength(0), 1];

            for (int k = 0; k < newX.GetLength(0); ++k)
            {
                for (int i = 0; i < matrixMem.GetLength(1); ++i)
                {
                    D[i, 0] = 1;
                    double tempD = 1;
                    for (int j = 0; j < matrixMem.GetLength(1); ++j)
                    {
                        if (j == i)
                        {
                            matrixMem[i, j] = null;
                        }
                        else
                        {
                            matrixMem[i, j] = X[i, 0] - X[j, 0];
                            D[i, 0] *= (double)matrixMem[i, j];
                            tempD *= newX[k, 0] - X[j, 0];
                        }
                    }
                    L[i, 0] = Y[i, 0] / D[i, 0];
                    newY[k, 0] += L[i, 0] * tempD;
                }
            }
            return newY;
        }
    }
}
