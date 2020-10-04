using NUnit.Framework;
using Xunit;

namespace StringCompressionTest
{
    public class Tests
    {
        [Theory]
        [InlineData("aaabbbbc", "a3b4c1")]

        public void Test1(string str1, string str2)
        {
            Assert.Pass();
        }
    }
}