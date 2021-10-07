using System;
using System.Linq;

namespace Calculator
{
    public static class InputParser
    {
        public static int Int(string number)
        {
            var result = (int)Double(number);
            return result;
        }

        public static double Double(string number)
        {
            var result = HandleSingleNumber(number);
            return result;
        }

        public static double[] Numbers(string numbers, char @operator)
        {
            if (numbers == null)
            {
                throw new ArgumentException(nameof(numbers));
            }

            var result = HandleMultipleNumbers(numbers, @operator);
            return result;
        }

        private static double[] HandleMultipleNumbers(string numbers, char @operator)
        {
            var numbersArray = numbers.Split(@operator);
            var parsedArray = numbersArray.Select(HandleSingleNumber).ToArray();
            return parsedArray;
        }

        private static double HandleSingleNumber(string number)
        {
            var result = double.TryParse(number, out var parsedNumber);
            if (result == false)
            {
                throw new ArgumentException(nameof(number));
            }

            return parsedNumber;
        }

    }
}
