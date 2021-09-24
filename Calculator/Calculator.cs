using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Calculator
    {
        private double sum;
        private bool isfirst = true;
        public bool IS_FIRST
        {
            get { return isfirst; }
        }

        public Calculator Addition(double value)
        {
            var sum = this.sum + value;
            this.SetSum(sum);
            return this;
        }

        public Calculator Addition(double[] values)
        {
            this.SetSum(values[0]);
            for (int i = 1; i < values.Length; i++)
            {
                this.Addition(values[i]);
            }
            return this;
        }

        public Calculator Subtraction(double value)
        {
            var sum = this.sum - value;
            this.SetSum(sum);
            return this;
        }

        public Calculator Subtraction(double[] values)
        {
            this.SetSum(values[0]);
            for (int i = 1; i < values.Length; i++)
            {
                this.Subtraction(values[i]);
            }
            return this;
        }

        public Calculator Division(double value)
        {
            if (value == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            var sum = this.sum / value;
            this.SetSum(sum);
            return this;
        }

        public Calculator Division(double[] values)
        {
            this.SetSum(values[0]);
            for (int i = 1; i < values.Length; i++)
            {
                this.Division(values[i]);
            }
            return this;
        }

        public Calculator Multiplication(double[] values)
        {
            this.SetSum(values[0]);
            for(int i = 1; i < values.Length; i++)
            {
                this.Multiplication(values[i]);
            }
            return this;
        }

        public Calculator Multiplication(double value)
        {
            var sum = this.sum * value;
            this.SetSum(sum);
            return this;
        }

        private void SetSum(double sum)
        {
            this.isfirst = false;
            this.sum = sum;
        }

        public double GetSum()
        {
            return this.sum;
        }

        public void Clear()
        {
            this.isfirst = true;
            this.sum = 0;
        }
    }
}
