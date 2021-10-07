using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xunit;

namespace Calculator.Tests
{
    public class InputTests
    {
        [Theory]
        [InlineData(Operators.Addition, '+')]
        [InlineData(Operators.Subtraction, '-')]
        [InlineData(Operators.Multiplication, '*')]
        [InlineData(Operators.Division, '/')]
        public void CharFromOperator_Addition_ReturnExpected(Operators @operator, char expected)
        {
            // Act
            var actual = Input.CharFromOperator(@operator);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
