using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public static class Task3
    {
        public delegate double _baseFunction(double item1, double item2);

        public static double MethodDeterminatFunc(_baseFunction[,] baseFunction, double[,] baseValue)
        {
            double[,] newMatrix = new double[baseFunction.GetLength(0), baseFunction.GetLength(1)];
            for (UInt16 i = 0; i < newMatrix.GetLength(0); ++i)
                for (UInt16 j = 0; j < newMatrix.GetLength(1); ++j)
                {
                    newMatrix[i, j] = baseFunction[i, j](baseValue[0, 0], baseValue[1, 0]);
                }
            return Determinat.Determinat_Method(newMatrix);
        }

        public static double[,] MethodDecision(double[,] baseX, double accyra)
        {
            _baseFunction[,] iakobi = new _baseFunction[2, 2];

            iakobi[0, 0] = (double x, double y) => (y / (Math.Cos(x * y + 0.4) * Math.Cos(x * y + 0.4) )-2*x);
            iakobi[0, 1] = (double x, double y) => x / (Math.Cos(x * y + 0.4) * Math.Cos(x * y + 0.4));
            iakobi[1, 0] = (double x, double y) => 1.2 * x;
            iakobi[1, 1] = (double x, double y) => 4 * y;

            _baseFunction[,] delta1 = new _baseFunction[2, 2];

            delta1[0, 0] = (double x, double y) => Math.Tan(x * y + 0.4) - x * x;
            delta1[0, 1] = (double x, double y) => x / (Math.Cos(x * y + 0.4) * Math.Cos(x * y + 0.4));
            delta1[1, 0] = (double x, double y) => 0.6 * x * x + 2 * y*y - 1;
            delta1[1, 1] = (double x, double y) => 4 * y;

            _baseFunction[,] delta2 = new _baseFunction[2, 2];

            delta2[0, 0] = (double x, double y) => (y / (Math.Cos(x * y + 0.4) * Math.Cos(x * y + 0.4)) - 2 * x);
            delta2[0, 1] = (double x, double y) => Math.Tan(x * y + 0.4) - x * x;
            delta2[1, 0] = (double x, double y) => 1.2 * x;
            delta2[1, 1] = (double x, double y) => 0.6 * x * x + 2 * y*y - 1;


            return RecursionDesicion(iakobi, delta1, delta2, baseX, accyra);
        }

        private static double[,] RecursionDesicion(_baseFunction[,] iakobi,
            _baseFunction[,] delta1, _baseFunction[,] delta2, double[,] baseX, double accyra)
        {
            double iakobiD = MethodDeterminatFunc(iakobi, baseX);
            double delta1D = MethodDeterminatFunc(delta1, baseX);
            double delta2D = MethodDeterminatFunc(delta2, baseX);

            double[,] newX = new double[2, 1];
            newX[0, 0] = baseX[0, 0] - delta1D / iakobiD;
            newX[1, 0] = baseX[1, 0] - delta2D / iakobiD;

            if (Math.Abs(newX[0, 0] - baseX[0, 0]) > accyra || Math.Abs(newX[1, 0] - baseX[1, 0]) > accyra)
                return RecursionDesicion(iakobi, delta1, delta2, newX, accyra);
            else
                return newX;
        }
    }
}
