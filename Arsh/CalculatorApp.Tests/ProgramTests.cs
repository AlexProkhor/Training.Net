using Xunit;

namespace CalculatorApplication.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData("1","+","5", true)]
        public void CheckArgsTrueTest(string first, string second, string fird, bool end)
        {
            string[] str = new string[3] { first, second, fird };
            var res = Program.CheckArgs(str);
            Assert.Equal(res, end);
        }

        [Theory]
        [InlineData("1", "5", false)]
        public void CheckArgsFalseTest(string first, string second, bool end)
        {
            string[] str = new string[2] { first, second };
            var res = Program.CheckArgs(str);
            Assert.Equal(res, end);
        }

        [Theory]
        [InlineData("1", "+", "5", 0)]
        [InlineData("1", "&&", "5", 2)]
        public void MainTest(string first, string second, string fird, int end)
        {
            string[] str = new string[3] { first, second, fird };
            var res = Program.Main(str);
            Assert.Equal(res, end);
        }

        [Theory]
        [InlineData("1", "5", 1)]
        public void MainLowArgTest(string first, string second, int end)
        {
            string[] str = new string[2] { first, second };
            var res = Program.Main(str);
            Assert.Equal(res, end);
        }
    }
}
