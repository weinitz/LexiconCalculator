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

        [Theory]
        [InlineData(new double[] { 1, 2 }, -1)]
        [InlineData(new double[] { -1, 2 }, -3)]
        public void SubtractionTests(double[] values, double expected)
        {

            var result = new Calculator().Subtraction(values).Sum;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new double[] { 1, 3 }, 0.3333)]
        [InlineData(new double[] { -1, 3 }, -0.3333)]
        [InlineData(new double[] { 3, -1 }, -3)]
        public void DivideTests(double[] values, double expected)
        {
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
        public void CalculateEmptyArray()
        {
            var values = new double[] {  };

            var calculator = new Calculator();
            
            var result = Assert.Throws<ArgumentNullException>(
                () => calculator.Division(values)
            );
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
        [InlineData(new double[] {1, 0, -1}, 0)]
        public void MultiplicationTests(double[] input, int expected)
        {
            var result = new Calculator().Multiplication(input).Sum;

            Assert.Equal(expected, result);
        }
    }
}