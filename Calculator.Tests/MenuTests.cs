using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.Tests
{
    public class MenuTests
    {
        [Fact]
        public void IsValidIndex()
        {
            var result = Assert.Throws<ArgumentOutOfRangeException>(
                () => new Menu().SetActiveMenu(999)
            );
        }

    }
}
