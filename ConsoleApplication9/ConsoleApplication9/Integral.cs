using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public static class Integral
    {
        public delegate double baseFunc(double x);
        public static double First(baseFunc func,double a,double b, double step){
            double n = (b-a)/step;
            double result = 0;
            for (double i = a; i <= b - step; i += step) {
                result += func(i);
            }
            return ((b - a) / n) * result;
        }

        public static double Second(baseFunc func, double a, double b, double step)
        {
            double n = (b - a) / step;
            double result = 0;
            for (double i = a + step; i <= b; i += step)
            {
                result += func(i);
            }
            return ((b - a) / n) * result;
        }

        public static double Third(baseFunc func, double a, double b, double step)
        {
            double n = (b - a) / step;
            double result = 0;
            for (double i = a+step; i <= b; i += step)
            {
                result += func(i-step + step/2f);
            }
            return ((b - a) / n) * result;
        }

        public static double MethodTrap(baseFunc func,double a, double b,double accur) {
            double n = 1000;
            double h = (b-a)/n;
            double temp = 0;

            for (double i = 0; i <= b-h; i += h) {
                temp += ((func(i) + func(i + h))*h) / 2;
            }

            return temp;
        }

        public static double MethodSimpsona(baseFunc func, double a, double b, double accur)
        {
            double n = 1001;
            double h = (b - a) / n;
            double temp = func(a) + func(b);

            for (double i = 0, j = 0; i <= b - h; i += h,j++)
            {
                if (j % 2 == 0)
                    temp += 2*func(i);
                else
                    temp += 4*func(i);
            }

            return (temp*h)/3f;
        }
    }
}
