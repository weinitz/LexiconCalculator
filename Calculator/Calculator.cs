using System;
using System.ComponentModel;
using System.Linq;

namespace Calculator
{
    public class Calculator
    {
        public const double MaximumSum = 1000;
        private bool _isFirst = true;
        private double _sum;

        public bool IsFirst
        {
            get => _isFirst || _sum == 0;
            private set => _isFirst = value;
        }

        public double Sum
        {
            get => _sum;
            private set
            {
                _sum = ValidateResult(value);
                IsFirst = false;
            }
        }

        public Calculator Operate(Operators @operator, double[] values)
        {
            return @operator switch
            {
                Operators.Addition => Addition(values),
                Operators.Subtraction => Subtraction(values),
                Operators.Division => Division(values),
                Operators.Multiplication => Multiplication(values),
                _ => throw new InvalidEnumArgumentException()
            };
        }

        public Calculator Calculate(double[] values, Action<double> action)
        {
            if (IsFirst)
            {
                var firstValue = values[0];
                Sum = firstValue;
                values = values.Skip(1).ToArray();
            }

            foreach (var value in values) action(value);

            return this;
        }

        public Calculator Addition(double[] values)
        {
            Calculate(values, Addition);
            return this;
        }

        private void Addition(double value)
        {
            Sum += value;
        }

        public Calculator Subtraction(double[] values)
        {
            Calculate(values, Subtraction);
            return this;
        }

        private void Subtraction(double value)
        {
            Sum -= value;
        }

        public Calculator Multiplication(params double[] values)
        {
            Calculate(values, Multiplication);
            return this;
        }

        private void Multiplication(double value)
        {
            Sum *= value;
        }

        public Calculator Division(double[] values)
        {
            Calculate(values, Division);
            return this;
        }

        private void Division(double value)
        {
            if (value == 0) throw new DivideByZeroException("Cannot divide by zero");
            Sum /= value;
        }

        public Calculator Clear()
        {
            IsFirst = true;
            Sum = 0;
            return this;
        }

        private static double ValidateResult(double sum)
        {
            if (sum > MaximumSum)
            {
                throw new OverflowException();
            }

            return sum;
        }
    }
}