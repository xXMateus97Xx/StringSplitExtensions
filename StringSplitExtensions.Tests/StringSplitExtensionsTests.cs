using StringSplitIndex;
using System;
using Xunit;

namespace StringSplitExtensions.Tests
{
    public class StringSplitExtensionsTests
    {
        const string Test = " StringSplitExtensionsTests AaA 123456  Test ";

        [Theory]
        [InlineData(Test, ' ', StringSplitOptions.None)]
        [InlineData(Test, ' ', StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, ' ', StringSplitOptions.TrimEntries)]
        [InlineData(Test, ' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, 'i', StringSplitOptions.None)]
        [InlineData(Test, 'i', StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, 'i', StringSplitOptions.TrimEntries)]
        [InlineData(Test, 'i', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, 'z', StringSplitOptions.None)]
        [InlineData(Test, 'z', StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, 'z', StringSplitOptions.TrimEntries)]
        [InlineData(Test, 'z', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", ' ', StringSplitOptions.None)]
        [InlineData(" ", ' ', StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", ' ', StringSplitOptions.TrimEntries)]
        [InlineData(" ", ' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", 'z', StringSplitOptions.None)]
        [InlineData(" ", 'z', StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", 'z', StringSplitOptions.TrimEntries)]
        [InlineData(" ", 'z', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        public void CharSplit(string str, char split, StringSplitOptions options)
        {
            var count = 0;
            var splitted = str.Split(split, options);

            foreach (var item in str.SplitFast(split, options))
            {
                Assert.True(item.SequenceEqual(splitted[count]));
                count++;
            }

            Assert.Equal(count, splitted.Length);
        }

        [Theory]
        [InlineData(Test, " ", StringSplitOptions.None)]
        [InlineData(Test, " ", StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, " ", StringSplitOptions.TrimEntries)]
        [InlineData(Test, " ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, "i", StringSplitOptions.None)]
        [InlineData(Test, "i", StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, "i", StringSplitOptions.TrimEntries)]
        [InlineData(Test, "i", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, "z", StringSplitOptions.None)]
        [InlineData(Test, "z", StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, "z", StringSplitOptions.TrimEntries)]
        [InlineData(Test, "z", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, "AaA", StringSplitOptions.None)]
        [InlineData(Test, "AaA", StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, "AaA", StringSplitOptions.TrimEntries)]
        [InlineData(Test, "AaA", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, "Test ", StringSplitOptions.None)]
        [InlineData(Test, "Test ", StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, "Test ", StringSplitOptions.TrimEntries)]
        [InlineData(Test, "Test ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", " ", StringSplitOptions.None)]
        [InlineData(" ", " ", StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", " ", StringSplitOptions.TrimEntries)]
        [InlineData(" ", " ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", "z", StringSplitOptions.None)]
        [InlineData(" ", "z", StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", "z", StringSplitOptions.TrimEntries)]
        [InlineData(" ", "z", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", "AaA", StringSplitOptions.None)]
        [InlineData(" ", "AaA", StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", "AaA", StringSplitOptions.TrimEntries)]
        [InlineData(" ", "AaA", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]

        public void StringSplit(string str, string split, StringSplitOptions options)
        {
            var count = 0;
            var splitted = str.Split(split, options);

            foreach (var item in str.SplitFast(split, options))
            {
                Assert.True(item.SequenceEqual(splitted[count]));
                count++;
            }

            Assert.Equal(count, splitted.Length);
        }

        [Theory]
        [InlineData(Test, new[] { ' ' }, StringSplitOptions.None)]
        [InlineData(Test, new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, new[] { ' ' }, StringSplitOptions.TrimEntries)]
        [InlineData(Test, new[] { ' ' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, new[] { 'i' }, StringSplitOptions.None)]
        [InlineData(Test, new[] { 'i' }, StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, new[] { 'i' }, StringSplitOptions.TrimEntries)]
        [InlineData(Test, new[] { 'i' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, new[] { 'z' }, StringSplitOptions.None)]
        [InlineData(Test, new[] { 'z' }, StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, new[] { 'z' }, StringSplitOptions.TrimEntries)]
        [InlineData(Test, new[] { 'z' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, new[] { 'A', 'a' }, StringSplitOptions.None)]
        [InlineData(Test, new[] { 'A', 'a' }, StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, new[] { 'A', 'a' }, StringSplitOptions.TrimEntries)]
        [InlineData(Test, new[] { 'A', 'a' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, new[] { 'T', 'e', 's', 't', ' ' }, StringSplitOptions.None)]
        [InlineData(Test, new[] { 'T', 'e', 's', 't', ' ' }, StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(Test, new[] { 'T', 'e', 's', 't', ' ' }, StringSplitOptions.TrimEntries)]
        [InlineData(Test, new[] { 'T', 'e', 's', 't', ' ' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", new[] { ' ' }, StringSplitOptions.None)]
        [InlineData(" ", new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", new[] { ' ' }, StringSplitOptions.TrimEntries)]
        [InlineData(" ", new[] { ' ' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", new[] { 'z' }, StringSplitOptions.None)]
        [InlineData(" ", new[] { 'z' }, StringSplitOptions.RemoveEmptyEntries)]
        [InlineData(" ", new[] { 'z' }, StringSplitOptions.TrimEntries)]
        [InlineData(" ", new[] { 'z' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)]

        public void StringSplitAny(string str, char[] split, StringSplitOptions options)
        {
            var count = 0;
            var splitted = str.Split(split, options);

            foreach (var item in str.SplitAnyFast(split, options))
            {
                Assert.True(item.SequenceEqual(splitted[count]));
                count++;
            }

            Assert.Equal(count, splitted.Length);
        }
    }
}