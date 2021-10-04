using System;
using Xunit;
using Calculator;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Constructor()
        {
            const double sum = 0;
            const bool isFirst = true;
            var calculator = new Calculator();
            Assert.NotNull(calculator);
            Assert.Equal(calculator.IsFirst, isFirst);
            Assert.Equal(calculator.GetSum(), sum);
        }

        [Fact]
        public void DivideTests()
        {
            const double num1 = 1;
            const double num2 = 3;
            const double expected = 0.3333;

            var result = new Calculator().Division(new[] {num1, num2}).GetSum();

            Assert.Equal(expected, result, 4);
        }

        [Fact]
        public void DivideTestsZero()
        {
            const double num1 = 1;
            const double num2 = 0;

            var result = Assert.Throws<DivideByZeroException>(
                () => new Calculator().Division(new[] { num1, num2 }));

            Assert.Equal("Cannot divide by zero", result.Message);
        }
    }
}
