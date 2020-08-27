using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public static class RengeKytta
    {
        public static double hMin = 0.0001;
        public static double hMax = 0.001;

        public delegate double baseFunc(double[] Y);
        static void FCN(double[] Y, double[] K, baseFunc[] func)
        {
            for (int i = 0; i < K.GetLength(0); ++i)
            {
                K[i] = func[i](Y);
            }
        }

        public static double[] Result(double[] Y0, double h, double a, double b, baseFunc[] func,double eps)
        {
            hMax = (b - a) /15.0;
            StreamWriter obj = new StreamWriter("Data.txt");
            double[] K1 = new double[Y0.GetLength(0)];
            double[] K2 = new double[Y0.GetLength(0)];
            double[] K3 = new double[Y0.GetLength(0)];
            double[] K4 = new double[Y0.GetLength(0)];

            double[,] Eps = new double[10000,2];

            double[] C = { 1 / 3.0, 2 / 3.0, 1 };
            double[] B = { 1 / 8.0, 3 / 8.0, 3 / 8.0, 1 / 8.0 };

            double A21 = 1 / 3.0;

            double A31 = -1 / 3.0;
            double A32 = 1;

            double A41 = 1;
            double A42 = -1;
            double A43 = 1;

            double[] YN = new double[Y0.GetLength(0)];
            obj.WriteLine(" x | y1 | y2 | e1 | e2");
            obj.WriteLine(" " + a + " | " + Y0[0] + " | " + Y0[1] + " | " + 0 + " | " + 0);

            int k = 0;
            for (double i = h; i <= b; i += h,++k)
            {
                #region 2h

                FCN(Y0, K1, func);
                for (int j = 0; j < YN.GetLength(0); ++j)
                {
                    YN[j] = Y0[j] + 2*h * (A21 * K1[j]);
                }

                FCN(YN, K2, func);
                for (int j = 0; j < YN.GetLength(0); ++j)
                {
                    YN[j] = Y0[j] + 2*h * (A31 * K2[j] + A32 * K1[j]);
                }

                FCN(YN, K3, func);
                for (int j = 0; j < YN.GetLength(0); ++j)
                {
                    YN[j] = Y0[j] + 2*h * (A41 * K3[j] + A42 * K2[j] + A43 * K1[j]);
                }

                FCN(YN, K4, func);
                for (int j = 0; j < YN.GetLength(0); ++j)
                {
                    YN[j] = Y0[j] + 2*h * (B[0] * K1[j] + B[1] * K2[j] + B[2] * K3[j] + B[3] * K4[j]);
                }

                Eps[k,0] = YN[0]; 
                Eps[k,1] = YN[1]; 
                #endregion

                #region 1h
                for (int u = 0;u != 2;++u,i += h){
                    FCN(Y0, K1, func);
                    for (int j = 0; j < YN.GetLength(0); ++j)
                    {
                        YN[j] = Y0[j] + h * (A21 * K1[j]);
                    }

                    FCN(YN, K2, func);
                    for (int j = 0; j < YN.GetLength(0); ++j)
                    {
                        YN[j] = Y0[j] + h * (A31 * K2[j] + A32 * K1[j]);
                    }

                    FCN(YN, K3, func);
                    for (int j = 0; j < YN.GetLength(0); ++j)
                    {
                        YN[j] = Y0[j] + h * (A41 * K3[j] + A42 * K2[j] + A43 * K1[j]);
                    }

                    FCN(YN, K4, func);
                    for (int j = 0; j < YN.GetLength(0); ++j)
                    {
                        YN[j] = Y0[j] + h * (B[0] * K1[j] + B[1] * K2[j] + B[2] * K3[j] + B[3] * K4[j]);
                    }
                    if(u==0)
                        obj.WriteLine(" " + i + " | " + YN[0] + " | " + YN[1]);
                    else
                        obj.Write(" " + i + " | " + YN[0] + " | " + YN[1]);

                    Y0[0] = YN[0];
                    Y0[1] = YN[1];
                }
                #endregion

                Eps[k,0] = Math.Abs(Eps[k,0] - YN[0]); 
                Eps[k,1] = Math.Abs(Eps[k,1] - YN[1]);

                if (Eps[k, 0] > eps || Eps[k, 1] > eps) {
                    i -= h;
                    if (h/2.0 > hMin)
                        h /= 2.0;
                    else
                        h = hMin;
                }

                if (Eps[k, 0] < eps || Eps[k, 1] < eps)
                {
                    if (2.0*h < hMax)
                    {
                        h *= 2.0;
                    }
                    else {
                        h = hMax;
                    }
                }

                obj.WriteLine(" | " + Eps[k,0] + " | " + Eps[k,1]);

            }
            obj.Close();
            return YN;
        }
    }
}