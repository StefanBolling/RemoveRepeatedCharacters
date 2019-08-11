using NUnit.Framework;
using RemoveRepeatedCharachters.TextParsers;

namespace Tests
{
    public class Tests
    {
        private const string textToParse = "aaabbbcccbb";
        private const string expectedResult = "abcb";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ForLoopTextParserShouldParseStringCorrectly()
        {
            // Arrange
            var textParser = new ForLoopTextParser();

            // Act
            var parsedText = textParser.RemoveRepeatedCharacters(textToParse);

            // Assert
            Assert.AreEqual(expectedResult, parsedText);
        }

        [Test]
        public void ParallelForLoopTextParserShouldParseStringCorrectly()
        {
            // Arrange
            var textParser = new ParallelForLoopTextParser();

            // Act
            var parsedText = textParser.RemoveRepeatedCharacters(textToParse);

            // Assert
            Assert.AreEqual(expectedResult, parsedText);
        }

        [Test]
        public void RecursiveTextParserShouldParseStringCorrectly()
        {
            // Arrange
            var textParser = new ParallelForLoopTextParser();

            // Act
            var parsedText = textParser.RemoveRepeatedCharacters(textToParse);

            // Assert
            Assert.AreEqual(expectedResult, parsedText);
        }
    }
}