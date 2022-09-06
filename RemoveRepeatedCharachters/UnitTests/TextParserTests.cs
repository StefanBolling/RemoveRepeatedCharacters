using NUnit.Framework;
using RemoveRepeatedCharacters.TextParsers;

namespace UnitTests;

public class TextParserTests
{
    private const string TextToParse = "aaabbbcccbb";
    private const string ExpectedResult = "abcb";

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
        var parsedText = textParser.RemoveRepeatedCharacters(TextToParse);

        // Assert
        Assert.AreEqual(ExpectedResult, parsedText);
    }

    [Test]
    public void ParallelForLoopTextParserShouldParseStringCorrectly()
    {
        // Arrange
        var textParser = new ParallelForLoopTextParser();

        // Act
        var parsedText = textParser.RemoveRepeatedCharacters(TextToParse);

        // Assert
        Assert.AreEqual(ExpectedResult, parsedText);
    }

    [Test]
    public void RecursiveTextParserShouldParseStringCorrectly()
    {
        // Arrange
        var textParser = new ParallelForLoopTextParser();

        // Act
        var parsedText = textParser.RemoveRepeatedCharacters(TextToParse);

        // Assert
        Assert.AreEqual(ExpectedResult, parsedText);
    }
}