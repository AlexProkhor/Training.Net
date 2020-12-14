using System;
using Xunit;
namespace CalculatorApplication.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(CalculatorOperations.Plus,1,2,3)]
        [InlineData(CalculatorOperations.Minus, 0, 1, -1)]
        [InlineData(CalculatorOperations.Multiply, 2, 2, 4)]
        [InlineData(CalculatorOperations.Divide, 10, 2, 5)]
        public void Calculate_CoupleOfData_ReturnsCorrectResults(CalculatorOperations operation, 
            double value1, double value2, double expected)
        {
            var actual = Calculator.Calculate(operation, value1, value2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculate_ThrowsNotSupportedException()
        {
            CalculatorOperations badOperation = 0;
             Assert.Throws<NotSupportedException>(() =>
              {
                  Calculator.Calculate(badOperation, 1, 2);
              });
        }
        [Fact]
        public void Calculate_Minus_Test()
        {
            var res = Calculator.Calculate(CalculatorOperations.Minus,5, 2);
            Assert.Equal(3, res);
        }

        [Fact]
        public void Calculate_Plus_Test()
        {
            var res = Calculator.Calculate(CalculatorOperations.Plus, 5, 2);
            Assert.Equal(7, res);
        }

        [Fact]
        public void Calculate_Multiply_Test()
        {
            var res = Calculator.Calculate(CalculatorOperations.Multiply, 5, 2);
            Assert.Equal(10, res);
        }

        [Fact]
        public void Calculate_Divide_Test()
        {
            var res = Calculator.Calculate(CalculatorOperations.Divide, 10, 2);
            Assert.Equal(5, res);
        }
    }
}
