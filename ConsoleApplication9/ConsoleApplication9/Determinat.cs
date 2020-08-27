using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    static class Determinat
    {
        public static double Determinat_Method(double[,] Array){
            if (Array.GetLength(0) == 1)
                return Array[0, 0];
            int N = Array.GetLength(0);
            int Nstr = 0;
            int Nstl = 0;
            int imod = 0, jmod = 0;
            double result = 0;
            double[,] ArrayMod = new double[N - 1, N - 1];
            for (int g = 0;g < N  ; g++,Nstl++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        if (i != Nstr && j != Nstl)
                        {
                            ArrayMod[jmod, imod] = Array[i, j];
                            jmod++;
                            if (jmod == N - 1) {
                                jmod = 0;
                                imod++;
                            }
                        }
                    }
                }
                result += Math.Pow(-1f, Nstl) * Array[Nstr,Nstl] * Determinat_Method(ArrayMod);
                imod = 0; jmod = 0;
                ArrayMod = new double[N - 1, N - 1];
            }
            return result;
        }
    }
}
