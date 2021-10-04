using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class DivideByZeroException : Exception
    {
        public DivideByZeroException(string message) : base(message)
        {
        }
    }
}
