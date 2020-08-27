using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    static class Gauss
    {
        public static double[,] Gauss_Method(double[,] Array_Base)
        {

            double[,] Array_Now = new double[Array_Base.GetLength(0), Array_Base.GetLength(1)];
            for (int i = 0; i < Array_Base.GetLength(0); i++)
                for (int j = 0; j < Array_Base.GetLength(1); j++)
                    Array_Now[i, j] = Array_Base[i, j];
            Console.WriteLine();
            int i_Max = 0; double Max = Array_Now[0, 0];
            for (int i = 1; i < Array_Now.GetLength(0); i++)
            {
                if (Max < Array_Now[i, 0])
                {
                    Max = Array_Now[i, 0];
                    i_Max = i;
                }
            }

            if (i_Max != 0)
            {
                for (int j = 0; j < Array_Now.GetLength(1); j++)
                {
                    double Time_Value = Array_Now[0, j];
                    Array_Now[0, j] = Array_Now[i_Max, j];
                    Array_Now[i_Max, j] = Time_Value;
                }
            }
            for (int i = 1; i < Array_Now.GetLength(0); i++)
            {
                for (int j = i; j < Array_Now.GetLength(0); j++)
                {
                    double Del = Array_Now[j, i - 1] / Array_Now[i - 1, i - 1];
                    for (int k = 0; k < Array_Now.GetLength(1); k++)
                    {
                        Array_Now[j, k] -= Del * Array_Now[i - 1, k];
                    }
                }
            }
            double del = Array_Now[0, 0];
            for (int i = 0; i < Array_Now.GetLength(1); i++)
            {
                Array_Now[0, i] /= del;
            }


            for (int i = 0; i < Array_Base.GetLength(0); i++)
            {
                for (int j = 0; j < Array_Base.GetLength(1); j++)
                    Console.Write("{0,-6} ", Array_Now[i, j]);

                Console.WriteLine();
            }
            Console.WriteLine();
            double[] Array_X = new double[Array_Now.GetLength(0)];
            for (int i = Array_Now.GetLength(0) - 1; i >= 0; i--)
            {
                Array_X[i] = Array_Now[i, Array_Now.GetLength(1) - 1] / Array_Now[i, i];
                for (int j = Array_Now.GetLength(0) - 1; j > i; j--)
                {
                    Array_X[i] -= Array_Now[i, j] * Array_X[j] / Array_Now[i, i];
                }
            }

            for (int i = 0; i < Array_X.GetLength(0); i++)
            {
                Console.Write("{0,-6} ", Array_X[i]);
            }

            return Array_Now;
        }
    }
}
