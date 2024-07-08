using System;
using Xunit;
using StringExtenderTask;

namespace StringExtenderTests
{
    public class GetFormattedSpaceTests
    {
        [Theory]
        [InlineData("abc",          "abc")]
        [InlineData("a b",          "a b")]
        [InlineData("a  b",         "a b")]
        [InlineData("a   b",        "a b")]
        [InlineData("a b c",        "a b c")]
        [InlineData("a  b  c",      "a b c")]
        [InlineData("a   b   c",    "a b c")]
        [InlineData("a  b",         "a b")]
        [InlineData("a  \t\r\nb",   "a b")]
        [InlineData("a&nbsp;b",     "a b")]
        [InlineData("a &nbsp;b",    "a b")]

        public void BaseTestCases(string unformattedString, string expectedResult )
        {
            Assert.Equal(unformattedString.GetFormattedSpace(), expectedResult);
        }

        [Fact]
        public void EmptyStringExceptionTestCase()
        {
            Action act = () => "".GetFormattedSpace();
            
            EmptyStringException exception = Assert.Throws<EmptyStringException>(act);
            
            Assert.Equal("Text is null or empty.", exception.Message);

        }
    }
}
