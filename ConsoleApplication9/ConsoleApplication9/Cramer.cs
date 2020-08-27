using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    static class Cramer
    {
        public static double[] Ctamer_Method(double [,] Array_A, double[] Array_B) { 
            double[] Result  = new double[Array_A.GetLength(0)];
            double Det_A = Determinat.Determinat_Method(Array_A);
            for (int i = 0; i < Result.GetLength(0); i++) {
                Result[i] = Determinat.Determinat_Method(Help_Cramer(i,Array_A,Array_B)) / Det_A;
            }
            return Result;
        }

        private static double[,] Help_Cramer(int j_base, double[,] Array_Base, double [] Array_NewVector) {
            double[,] Array_New = new double[Array_Base.GetLength(0), Array_Base.GetLength(1)];
            for (int i = 0; i < Array_Base.GetLength(0); i++)
            {
                for (int j = 0; j < Array_Base.GetLength(1); j++) {
                    if(j == j_base)
                        Array_New[i, j] = Array_NewVector[i];
                    else
                        Array_New[i, j] = Array_Base[i, j];
                }
            }
            return Array_New;
        }
    }
}
