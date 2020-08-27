using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    static class MethodOFSimpleIteration
    {
        public delegate double Move(double item1, double item2);

        public static double [,] MatrixMove(double[,] aBase, double[,] bBase, Move objectMove)
        {
            if (aBase.GetLength(0) != bBase.GetLength(0) || aBase.GetLength(1) != bBase.GetLength(1))
                return null;
            else
            {
                double[,] cNew = new double[aBase.GetLength(0), aBase.GetLength(1)];
                for (UInt16 i = 0; i < aBase.GetLength(0); ++i)
                {
                    for (UInt16 j = 0; j < aBase.GetLength(1); ++j)
                    {
                        cNew[i, j] = objectMove(aBase[i, j], bBase[i, j]);
                    }
                }
                return cNew;
            }
        }

        public static double[,] CView(double [,] cBase) {
            double[,] cNew = new double[cBase.GetLength(0), cBase.GetLength(1)];
            for (UInt16 i = 0; i < cNew.GetLength(0); ++i) {
                for (UInt16 j = 0; j < cNew.GetLength(1); ++j) { 
                    cNew[i,j] = -(cBase[i,j]/cBase[i,i]);
                }
                cNew[i, i] = 0;
            }
            return cNew;
        }

        public static double[,] FView(double[,] cBase,double[,] fBase) {
            double[,] fNew = new double[fBase.GetLength(0), fBase.GetLength(1)];
            for (UInt16 i = 0; i < fNew.GetLength(0); ++i)
            {
                for (UInt16 j = 0; j < fNew.GetLength(1); ++j)
                {
                    fNew[i, j] = (fBase[i, j] / cBase[i, i]);
                }
            }
            return fNew;
        }

        public static double [,] MethodCalc(double[,] cBase, double[,] fBase, double[,] xNumber, double accuracu)
        {
            double[,] xNumberNext = MatrixMove(Matrix.Multiplication(cBase, xNumber), fBase,
                (double _it1, double _it2) => _it1 + _it2);
            double[,] forAccuracy = MatrixMove(xNumberNext, xNumber, 
                (double _it1, double _it2) => Math.Abs(_it1 - _it2));
            try
            {
                for (Int16 j = 0; j < forAccuracy.GetLength(1); ++j)
                {
                    
                    if (forAccuracy[0, j] > accuracu)
                        throw new Exception();
                }
            }
            catch
            {
                xNumberNext = MethodCalc(cBase, fBase, xNumberNext, accuracu);
            }
            return xNumberNext;
        }

        public static double[,] Zeidel(double[,] cBase, double[,] fBase, double[,] xNumber, double accuracu)
        {
            double[,] xNumberNext = new double[xNumber.GetLength(0), xNumber.GetLength(1)];
            for (UInt16 i = 0; i < xNumberNext.GetLength(0); ++i)
                xNumberNext[i, 0] = xNumber[i,0];
            for (UInt16 i = 0; i < cBase.GetLength(0); ++i) {
                double temp = 0;
                for (UInt16 j = 0; j < cBase.GetLength(1); ++j) { 
                    temp += xNumberNext[j,0] * cBase[i,j];
                }
                xNumberNext[i,0] = temp;
            }

            double[,] forAccuracy = MatrixMove(xNumberNext, xNumber,
                (double _it1, double _it2) => Math.Abs(_it1 - _it2));
            try
            {
                for (UInt16 j = 0; j < forAccuracy.GetLength(1); ++j)
                {

                    if (forAccuracy[0, j] > accuracu)
                        throw new Exception();
                }
            }
            catch
            {
                xNumberNext = MethodCalc(cBase, fBase, xNumberNext, accuracu);
            }
            return xNumberNext;
        }
    }
}
