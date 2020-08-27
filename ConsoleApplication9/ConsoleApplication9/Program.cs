using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Back
            //double[,] A = {
            // {1,2,3,4},
            // {5,6,7,8},
            // {9,10,11,12},
            // {13,14,15,16}};
            //double[,] B ={
            // {27,3,6},
            // {8,2,8},
            // {6,8,2}};
            //Console.WriteLine(Determinat.Determinat_Method(B));

            //double[,] A ={
            //{2,4,1},
            //{5,2,1},
            //{2,3,4}};
            //double[] B = new double[3];
            //B[0] = 36;
            //B[1] = 47;
            //B[2] = 37;
            //double[] C = Cramer.Ctamer_Method(A, B);

            //double[,] C_D = new double[1, 3];
            //C_D[0, 0] = C[0];
            //C_D[0, 1] = C[1];
            //C_D[0, 2] = C[2];

            //double[,] B_Dobl = Matrix.Multiplication(A, C_D);

            //double[,] F ={
            //{2,4,1,36},
            //{5,2,1,47},
            //{2,3,4,37}};

            //Gauss.Gauss_Method(F);
#region test
            //DateTime Now = DateTime.Now;
            //double Post = 0,Pres = 0,Post_N = 0;
            //for (int g = 0; g < 10; g++)
            //{
            //    for (int i = 0; i < 10000000; i++) ;

            //    Post += (DateTime.Now - Now).Milliseconds;
            //    Now = DateTime.Now;

            //    for (int i = 0; i < 10000000; i = i + 1) ;

            //    Post_N += (DateTime.Now - Now).Milliseconds;
            //    Now = DateTime.Now;


            //    for (int i = 0; i < 10000000; ++i) ;

            //    Pres += (DateTime.Now - Now).Milliseconds;
                
            //}
            //Console.WriteLine((Post / 100000000f).ToString() + " " + (Pres / 1000000000f).ToString() + " !" + (Post_N / 1000000000f).ToString());
            

            //6,37E-06 3,25E-07 !3,25E-07
#endregion
            #endregion 

            //double[,] A ={
            //{20.9,1.2,2.1,0.9},
            //{1.2,21.2,1.5,2.5},
            //{2.1,1.5,19.8,1.3},
            //{0.9,2.5,1.3,32.1}};

            //double[,] C ={
            //{4,5,7},
            //{1,1,9},
            //{3,5,1}};

            //double[,] B = new double[4,1];
            //B[0,0] = 21.7;
            //B[1,0] = 27.46;
            //B[2, 0] = 28.76;
            //B[3, 0] = 49.72;

            //double[,] X = new double[4, 1];
            //X[0, 0] = 21.7;
            //X[1, 0] = 27.46;
            //X[2, 0] = 28.76;
            //X[3, 0] = 49.72;

            //double [,]result =  MethodOFSimpleIteration.MethodCalc(
            //      MethodOFSimpleIteration.CView(A),MethodOFSimpleIteration.FView(A, B), X, 0.001);
            //double[,] result2 = Matrix.Multiplication(A,result);

            //double[,] resultZ = MethodOFSimpleIteration.Zeidel(
            //   MethodOFSimpleIteration.CView(A), MethodOFSimpleIteration.FView(A, B), X, 0.001);

            //double[,] result = InverseMatrix.InverseMatrixMethod(C);
            //double [,] result2 = Matrix.Multiplication(C,result);

            //double[,] X = new double[2, 1];
            //X[0, 0] = 1;
            //X[1, 0] = 0.32;
            //double[,] Y = Task3.MethodDecision(X, 0.001);
            //double a = Math.Tan(Y[0, 0] * Y[1, 0] + 0.4) - Y[0, 0] * Y[0, 0];
            //double b = 0.6 * Y[0, 0] * Y[0, 0] + 2 * Y[1, 0] * Y[1, 0]-1;

            //IterSNY._baseFunction[] baseFunc = new IterSNY._baseFunction[]{(double _x,double _y)=>_x -0.256*(_x*_x + _y*_y -1)-0.307*(_x*_x*_x - _y),
            //    (double _x,double _y)=>_y + 0.49*(_x*_x + _y*_y -1) + 0.41*(_x*_x*_x - _y)};
            //double[] Y = IterSNY.Method(baseFunc,0.8,0.6,0.01);
            //double a = Y[0] * Y[0] + Y[1] * Y[1] - 1;
            //double b = Y[0] * Y[0] * Y[0] - Y[1] ;

            //double[,] X = new double[2, 1];
            //X[0, 0] = 1;
            //X[1, 0] = 2;
            //double[,] Y = IterSlAY.MethodDecision(X, 0.001);
            //double a = Y[0, 0] * Y[1, 0] - 1;
            //double b = Y[0, 0] * Y[0, 0] + Y[1, 0] * Y[1, 0] - 4;


            //double[,] Y = new double[5,1];
            //Y[0, 0] = 1.172;
            //Y[1, 0] = 1.179;
            //Y[2, 0] = 1.182;
            //Y[3, 0] = 1.186;
            //Y[4, 0] = 1.189;

            //double[,] X = new double[5, 1];
            //X[0, 0] = 1.62;
            //X[1, 0] = 1.64;
            //X[2, 0] = 1.65;
            //X[3, 0] = 1.67;
            //X[4, 0] = 1.68;

            ////double [,] Z = Interpol.InterMethod(Y,X);

            //double[,] newX = new double[1, 1];
            //newX[0, 0] = 1.64;

            //double[,] Z = Langrandg.MethodLangr(X, Y, newX);

            //double a, b, c;

            //a = Integral.First((double _x) => _x * _x, 0, 3, 3 / 20f);
            //b = Integral.Second((double _x) =>_x * _x, 0, 3, 3 / 20f);
            //c = Integral.Third((double _x) =>_x * _x, 0, 3, 3 / 20f);

            //double[,] Y = new double[5, 1];
            //Y[0, 0] = 1.172;
            //Y[1, 0] = 1.179;
            //Y[2, 0] = 1.182;
            //Y[3, 0] = 1.186;
            //Y[4, 0] = 1.189;

            //double[,] X = new double[5, 1];
            //X[0, 0] = 1.62;
            //X[1, 0] = 1.64;
            //X[2, 0] = 1.65;
            //X[3, 0] = 1.67;
            //X[4, 0] = 1.68;


            //double[,] Y = new double[2, 1];
            //Y[0, 0] = 0;
            //Y[1, 0] = 1;
            

            //double[,] X = new double[2, 1];
            //X[0, 0] = 0;
            //X[1, 0] = 1;

           // double result = Interpol.InterMethodDif(Y,X,1.64);


            //double[,] Y = new double[6, 1];
            //Y[0, 0] = 0;
            //Y[1, 0] = 1;
            //Y[2, 0] = 2;
            //Y[3, 0] = 3;
            //Y[4, 0] = 4;
            //Y[5, 0] = 5;

            //double[,] X = new double[6, 1];
            //X[0, 0] = 0;
            //X[1, 0] = 1;
            //X[2, 0] = 2;
            //X[3, 0] = 3;
            //X[4, 0] = 4;
            //X[5, 0] = 5;

            //double[,] Y = new double[2, 1];
            //Y[0, 0] = 3.32;
            //Y[1, 0] = 3.491;
            ////Y[2, 0] = 3.669;
            ////Y[3, 0] = 3.857;
            ////Y[4, 0] = 4.055;
            ////Y[5, 0] = 4.263;
            ////Y[6, 0] = 4.482;
            ////Y[7, 0] = 4.712;
            ////Y[8, 0] = 4.953;
            ////Y[9, 0] = 5.203;

            //double[,] X = new double[2, 1];
            //X[0, 0] = 1.2;
            //X[1, 0] = 1.25;
            //X[2, 0] = 1.3;
            //X[3, 0] = 1.35;
            //X[4, 0] = 1.4;
            //X[5, 0] = 1.45;
            //X[6, 0] = 1.5;
            //X[7, 0] = 1.55;
            //X[8, 0] = 1.6;
            //X[9, 0] = 1.65;

            //double x = 1.22;

            //double result1 = Interpol.FirstInterpolN(Y, X, x);

            //double result2 = Interpol.SecondInterpolN(Y, X, x);

            //double result3 = Interpol.InterMethodDif(Y,X,x);

            //double x2 = 1.58;

            //double result12 = Interpol.FirstInterpolN(Y, X, x2);

            //double result22 = Interpol.SecondInterpolN(Y, X, x2);

            //double result32 = Interpol.InterMethodDif(Y, X, x2);

            //double result1 = Integral.MethodTrap((double _x) => _x * _x, 0, 3, 3 / 20f);
            //double result2 = Integral.MethodSimpsona((double _x) => _x * _x, 0, 3, 3 / 20f);

            //double a, b, c;

            //a = Integral.First((double _x) => _x * _x, 0, 3, 3 / 20f);
            //b = Integral.Second((double _x) =>_x * _x, 0, 3, 3 / 20f);
            //c = Integral.Third((double _x) => _x * _x, 0, 3, 3 / 20f);

            double[] RY = RengeKytta.Result(new double[]{1.01,3},0.1,0,20,new RengeKytta.baseFunc[]{((double[] Y ) => 1 + Y[0]*Y[0]*Y[1] - 4*Y[0]),(double[] Y)=> 3*Y[0]-Y[0]*Y[0]*Y[1]},0.0001);
            Console.ReadLine();
        }
    }
}