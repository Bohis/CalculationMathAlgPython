using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    //не работает, на python раюотает
    public static class Interpol
    {
        public static double[,] InterMethod(double[,] y, double[,] x)
        {
            double[,] newX = new double[x.GetLength(0), x.GetLength(0)];
            for (int i = 0; i < newX.GetLength(0); ++i)
            {
                for (int j = 0; j < newX.GetLength(1); ++j)
                {
                    if (j == 0)
                    {
                        newX[i, j] = 1;
                    }
                    else
                    {
                        newX[i, j] = Math.Pow(x[i, 0], j);
                    }
                }
            }
            newX = InverseMatrix.InverseMatrixMethod(newX);
            return Matrix.Multiplication(newX, y);
        }

        public static double InterMethodDif(double[,] arrayY, double[,] arrayX, double x)
        {
            double[,] FiniteDif = InterDif(arrayY, arrayX);

            double temp = arrayY[0, 0];

            for (int i = 1; i < FiniteDif.GetLength(0); ++i)
            {
                temp += Composition(arrayX, x, -1, i - 1) * FiniteDif[i, 0];
            }

            return temp;
        }

        private static double[,] InterDif(double[,] y, double[,] x)
        {
            double[,] FiniteDif = new double[y.GetLength(0), 1];
            FiniteDif[0, 0] = y[0, 0];
            for (int i = 1; i < FiniteDif.GetLength(0); ++i)
            {
                double temp = 0;
                for (int j = 0; j <= i; ++j)
                {
                    temp += y[j, 0] / Composition(x, x[j, 0], j, i);
                }
                FiniteDif[i, 0] = temp;
            }
            return FiniteDif;
        }

        private static double Composition(double[,] xArray, double x, double xIndex, double maxIndex)
        {
            double temp = 1;
            for (int i = 0; i <= maxIndex; ++i)
            {
                if (i != xIndex)
                    temp *= (x - xArray[i, 0]);
            }
            return temp;
        }

        public static double FirstInterpolN(double[,] y, double[,] x, double valueX)
        {
            double h = x[1, 0] - x[0, 0];

            double temp = y[0, 0], q = (valueX - x[0, 0]) / h;

            double[,] difTab = new double[y.GetLength(0), y.GetLength(0)];

            for (int i = 0; i < y.GetLength(0); ++i)
            {
                difTab[i, 0] = y[i, 0];
            }

            for (int j = 1; j < difTab.GetLength(1); ++j)
            {
                for (int i = 0; i < difTab.GetLength(0) - j; ++i)
                {
                    difTab[i, j] = difTab[i + 1, j - 1] - difTab[i, j - 1];
                }
            }

            baseMethod coof = (double _q, double _n) =>
            {
                double result = 1f / Factorial(_n);
                for (int i = 1; i <= _n; ++i)
                {
                    result *= _q - i + 1;
                }
                return result;
            };

            for (int j = 1; j < difTab.GetLength(1); ++j)
            {
                temp += coof(q, j) * difTab[0, j];
            }

            return temp;

        }

        private static double Factorial(double n)
        {
            if (n == 1)
                return 1;
            return n * Factorial(n - 1);
        }
        delegate double baseMethod(double q, double n);

        public static double SecondInterpolN(double[,] y, double[,] x, double valueX)
        {
            double h = x[1, 0] - x[0, 0];

            double temp = y[y.GetLength(0)-1,0 ], q = (valueX - x[x.GetLength(0) - 1, 0]) / h;

            double[,] difTab = new double[y.GetLength(0), y.GetLength(0)];

            for (int i = 0; i < y.GetLength(0); ++i)
            {
                difTab[i, 0] = y[i, 0];
            }

            for (int j = 1; j < difTab.GetLength(1); ++j)
            {
                for (int i = 0; i < difTab.GetLength(0) - j; ++i)
                {
                    difTab[i, j] = difTab[i + 1, j - 1] - difTab[i, j - 1];
                }
            }

            baseMethod coof = (double _q, double _n) =>
            {
                double result = 1f / Factorial(_n);
                for (int i = 1; i <= _n; ++i)
                {
                    result *= _q + i - 1;
                }
                return result;
            };

            for (int j = 1, i = difTab.GetLength(0) - 2; i >= 0; ++j,--i)
            {
                temp += coof(q, j) * difTab[i, j];
            }

            return temp;

        }
    }

}