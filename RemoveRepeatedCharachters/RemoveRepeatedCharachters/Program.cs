using Microsoft.Extensions.DependencyInjection;
using RemoveRepeatedCharacters.TextParsers.Interfaces;
using RemoveRepeatedCharacters.TextParsers.Models;
using System;
using System.Diagnostics;

namespace RemoveRepeatedCharacters;

class Program
{
    private const string TextToParse = "aaabbbcccbb";

    static void Main(string[] args)
    {
        var serviceProvider = IOC.Initialize();

        foreach (var parser in serviceProvider.GetServices<ITextParser>())
        {
            var result = Measure(parser, TextToParse);
            Console.WriteLine(
                $"{parser.Name}: Unparsed string {TextToParse} Result is {result.ParsedText} " +
                $"and took {result.ExecutionTime.TotalMilliseconds} milliseconds");
        }

        Console.ReadLine();
    }

    private static ParsedTextAndExecutionTime Measure(ITextParser parser, string textToParse)
    {
        var stopwatch = Stopwatch.StartNew();
        var parsedText = parser.RemoveRepeatedCharacters(textToParse);
        stopwatch.Stop();

        return new ParsedTextAndExecutionTime(parsedText, stopwatch.Elapsed);
    }
}
