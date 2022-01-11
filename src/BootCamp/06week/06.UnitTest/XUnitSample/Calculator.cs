using System;
using System.Collections.Generic;
using System.Text;
namespace XUnitSample
{
    public class Calculator
    {
        public int Addition(int n1, int n2) => n1 + n2;
        public int Multiplication(int n1, int n2) => n1 * n2;
        
        //public int Subtraction(int n1, int n2) => n1 — n2; 
        public double Division(double n1, double n2) => n1 / n2;
    }

}