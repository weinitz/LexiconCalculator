using System;
using System.ComponentModel;

namespace Calculator
{
    public static class Input
    {
        public static char CharFromOperator(Operators @operator)
        {
            return @operator switch
            {
                Operators.Addition => '+',
                Operators.Subtraction => '-',
                Operators.Division => '/',
                Operators.Multiplication => '*',
                _ => throw new InvalidEnumArgumentException()
            };
        }

        public static void AskForNumbers(Calculator calculator, Operators @operator)
        {
            var operatorChar = CharFromOperator(@operator);
            AskForNumbers(calculator, operatorChar);
        }

        public static void AskForNumbers(Calculator calculator, char operatorChar)
        {
            Console.Clear();
            Console.WriteLine("Enter number(s) separated by {0}", operatorChar);

            if (!calculator.IsFirst) Console.Write("{0}{1}", calculator.Sum, operatorChar);
        }

        public static int Int()
        {
            var input = Console.ReadLine();
            return InputParser.Int(input);
        }

        public static double[] Numbers(Operators @operator)
        {
            var operatorChar = CharFromOperator(@operator);
            return Numbers(operatorChar);
        }

        public static double[] Numbers(char operatorChar)
        {
            var input = Console.ReadLine();
            return Numbers(input, operatorChar);
        }

        public static double[] Numbers(string input, char operatorChar)
        {
            return InputParser.Numbers(input, operatorChar);
        }
    }
}