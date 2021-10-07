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
        [InlineData(Operators.Addition)]
        public void CharFromOperator_Addition_ReturnsPlus(Operators @operator)
        {
            var expected = '+';

            // Act
            var actual = Input.CharFromOperator(@operator);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
