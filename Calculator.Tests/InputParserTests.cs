using System;
using Xunit;

namespace Calculator.Tests
{
    public class InputParserTests
    {
        [Fact]
        public void Int_SingleNumber_ReturnsSameNumber()
        {
            const double expected = 0;
            var actual = InputParser.Int("0");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Int_EmptyString_ThrowsArgumentException()
        {
            Action actual = () => InputParser.Int("");
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Numbers_TwoNumbers_ReturnsArray()
        {
            var actual = InputParser.Numbers("1+2", '+');

            Assert.IsType<double[]>(actual);
            Assert.Equal(2, actual.Length);
            Assert.Equal(1, actual[0]);
            Assert.Equal(2, actual[1]);
        }

        [Theory]
        [InlineData(null, '*')]
        [InlineData("a", '+')]
        public void Numbers_InputNullOrAlphabetic_ThrowsArgumentException(string input, char operatorChar)
        {
            Action actual = () => InputParser.Numbers(input, operatorChar);

            Assert.Throws<ArgumentException>(actual);
        }
    }
}