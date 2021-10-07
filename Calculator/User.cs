using System;
using System.ComponentModel;

namespace Calculator
{
    public class User
    {
        public User OperateCalculator(Calculator calculator, Operators @operator)
        {
            Input.AskForNumbers(calculator, @operator);
            var values = Input.Numbers(@operator);
            calculator.Operate(@operator, values);
            return this;
        }


    }
}
