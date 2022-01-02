using System;

namespace hw8.Services
{
    public class Calculator: ICalculator
    {
        public double Add(double arg1, double arg2) => arg1 + arg2;

        public double Subtract(double arg1, double arg2) => arg1 - arg2;

        public double Divide(double arg1, double arg2) => arg2 == 0 ?
            double.NaN : arg1 / arg2;

        public double Multiply(double arg1, double arg2) => arg1 * arg2;
    }
}