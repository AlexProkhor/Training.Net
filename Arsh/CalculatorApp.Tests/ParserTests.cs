using Xunit;
namespace CalculatorApplication.Tests
{
    public class ParserTests
    {
        [Theory]
        [InlineData("1,7976931348623157E+308", double.MaxValue)]
        [InlineData("5", 5)]
        [InlineData("-1", -1)]
        [InlineData("0", 0)]
        public void TryParseValue_ReturnsTrue(string arg, double expected)
        {
            var actual = Parser.TryParseValue(arg, "", out double value);
            Assert.Equal(expected, value);
            Assert.True(actual);
        }

        [Fact]
        public void TryParseValue_ReturnsFalse()
        {
            var actual = Parser.TryParseValue("Not double", "", out _);
            Assert.False(actual);
        }

        [Theory]
        [InlineData("+", CalculatorOperations.Plus)]
        [InlineData("-", CalculatorOperations.Minus)]
        [InlineData("*", CalculatorOperations.Multiply)]
        [InlineData("/", CalculatorOperations.Divide)]
        public void TryParseOperation_ReturnsTrue(string strOperation, CalculatorOperations expected)
        {
            var actual = Parser.TryParseOperation(strOperation, out var operation);
            Assert.Equal(expected, operation);
            Assert.True(actual);
        }

        [Fact]
        public void TryParseOperation_ReturnsFalse()
        {
            var actual = Parser.TryParseOperation("Not operation", out _);
            Assert.False(actual);
        }

        [Theory]
        [InlineData(1)]
        public void WriteResult_GetResult(double result)
        {
           Parser.WriteResult(result);
        }
    }
}
