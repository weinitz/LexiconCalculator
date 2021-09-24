using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class DivideByZeroException : Exception
    {
        public DivideByZeroException(string message) : base(message)
        {
        }
    }
}
