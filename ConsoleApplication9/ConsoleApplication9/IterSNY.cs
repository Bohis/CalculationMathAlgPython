using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public static class IterSNY
    {
        public delegate double _baseFunction(double item1, double item2);
        static public double[] Method(_baseFunction[] function, double x, double y,double accyracu) {
            double xnew = function[0](x,y);
            double ynew = function[1](x,y);

            //Console.WriteLine(xnew.ToString() + " " + ynew.ToString());
            double[] newArray = new double[]{xnew,ynew};
            if (Math.Abs(xnew - x) <= accyracu && Math.Abs(ynew - y) <= accyracu)
                return newArray;
            else 
                return Method(function,xnew,ynew,accyracu);
        }
    }
}
