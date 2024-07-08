using System;
using System.Text.RegularExpressions;

namespace StringExtenderTask
{
    public static class StringExtender
    {
        public static string GetFormattedSpace(this string unformattedText)
        {
            if (string.IsNullOrEmpty(unformattedText))
                throw new EmptyStringException("Text is null or empty.");

            string result = unformattedText
                .Replace("\u00a0", " ")
                .Replace("&nbsp;", " ");

            result = Regex.Replace(result, "\\s+", " ");

            return result;
        }
    }

    public class EmptyStringException : Exception
    {
        public EmptyStringException(string message) : base(message) { }
    }
}
