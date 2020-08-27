using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public static class InverseMatrix
    {
        static public double[,] Transpose(double[,] matrix)
        {
            double[,] newMatrix = new double[matrix.GetLongLength(1), matrix.GetLongLength(0)];
            for (int i = 0; i < newMatrix.GetLongLength(0); i++)
                for (int j = 0; j < newMatrix.GetLongLength(1); j++)
                    newMatrix[i, j] = matrix[j, i];
            return newMatrix;
        }

        public static double[,] InverseMatrixMethod(double[,] baseMatrix)
        {
            double[,] newMatrix = new double[baseMatrix.GetLength(0), baseMatrix.GetLength(1)];
            for (UInt16 i = 0; i < newMatrix.GetLength(0); ++i)
                for (UInt16 j = 0; j < newMatrix.GetLength(1); ++j)
                {
                    double[,] temp = new double[newMatrix.GetLength(0) - 1, newMatrix.GetLength(1) - 1];
                    UInt16 iSpec = 0, jSpec = 0;
                    for (UInt16 it = 0; it < newMatrix.GetLength(0); ++it)
                    {
                        for (UInt16 jt = 0; jt < newMatrix.GetLength(1); ++jt)
                        {
                            if (i != it && j != jt)
                            {
                                temp[iSpec, jSpec] = baseMatrix[it, jt];
                                ++jSpec;
                                if (jSpec == temp.GetLength(1)) {
                                    jSpec = 0;
                                    ++iSpec;
                                }
                            }
                        }
                    }
                    newMatrix[i, j] = Math.Pow(-1f, i+j)  * Determinat.Determinat_Method(temp);
                }

            newMatrix = Transpose(newMatrix);

            double inverseDeterminat = 1f/Determinat.Determinat_Method(baseMatrix);

            for (UInt16 i = 0; i < newMatrix.GetLength(0); ++i)
                for (UInt16 j = 0; j < newMatrix.GetLength(1); ++j) {
                    newMatrix[i, j] = newMatrix[i, j] * inverseDeterminat;
                }
            return newMatrix;
        }

    }
}