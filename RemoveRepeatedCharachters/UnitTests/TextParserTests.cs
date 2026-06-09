using System.Collections.Generic;
using NUnit.Framework;
using RemoveRepeatedCharacters.TextParsers;
using RemoveRepeatedCharacters.TextParsers.Interfaces;

namespace UnitTests;

public class TextParserTests
{
    private static IEnumerable<ITextParser> Parsers()
    {
        yield return new ForLoopTextParser();
        yield return new ParallelForLoopTextParser();
        yield return new RecursiveTextParser();
    }

    private static IEnumerable<TestCaseData> ParseCases()
    {
        foreach (var parser in Parsers())
        {
            var name = parser.Name;

            yield return new TestCaseData(parser, "aaabbbcccbb").Returns("abcb").SetName($"{name}_CollapsesRuns");
            yield return new TestCaseData(parser, "").Returns("").SetName($"{name}_EmptyString");
            yield return new TestCaseData(parser, "a").Returns("a").SetName($"{name}_SingleChar");
            yield return new TestCaseData(parser, "aaaa").Returns("a").SetName($"{name}_AllSame");
            yield return new TestCaseData(parser, "abc").Returns("abc").SetName($"{name}_NoRepeats");
            yield return new TestCaseData(parser, "aabbaa").Returns("aba").SetName($"{name}_RepeatingRuns");
        }
    }

    [TestCaseSource(nameof(ParseCases))]
    public string ShouldRemoveConsecutiveRepeatedCharacters(ITextParser parser, string input)
    {
        return parser.RemoveRepeatedCharacters(input);
    }

    [TestCaseSource(nameof(Parsers))]
    public void ShouldBeStatelessAcrossCalls(ITextParser parser)
    {
        // Calling the same instance twice must not accumulate state from the first call.
        parser.RemoveRepeatedCharacters("aaabbb");
        var second = parser.RemoveRepeatedCharacters("xxyy");

        Assert.That(second, Is.EqualTo("xy"));
    }
}
