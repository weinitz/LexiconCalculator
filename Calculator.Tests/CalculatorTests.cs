using System;
using Xunit;

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
            Assert.Equal(calculator.Sum, sum);
        }

        [Fact]
        public void AdditionTests()
        {
            var values = new double[] {1, 3};
            const double expected = 4;

            var result = new Calculator().Addition(values).Sum;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SubtractionTests()
        {
            var values = new double[] {3, 2};
            const double expected = 1;

            var result = new Calculator().Subtraction(values).Sum;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivideTests()
        {
            var values = new double[] {1, 3};
            const double expected = 0.3333;

            var result = new Calculator().Division(values).Sum;

            Assert.Equal(expected, result, 4);
        }

        [Fact]
        public void DivideTestsZero()
        {
            var values = new double[] {1, 0};

            var calculator = new Calculator();

            var result = Assert.Throws<DivideByZeroException>(
                () => calculator.Division(values)
            );

            Assert.Equal("Cannot divide by zero", result.Message);
        }

        [Fact]
        public void AdditionSumToHigh()
        {
            var calculator = new Calculator();

            Assert.Throws<OverflowException>(
                () => calculator.Addition(new[] {Calculator.MaximumSum + 1})
            );
        }

        [Theory]
        [InlineData(new double[] {1, 2, 3}, 6)]
        [InlineData(new double[] {1, 2}, 2)]
        public void MultiplicationTests(double[] input, int expected)
        {
            var result = new Calculator().Multiplication(input).Sum;

            Assert.Equal(expected, result);
        }
    }
}