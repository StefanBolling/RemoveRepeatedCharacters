using Microsoft.Extensions.DependencyInjection;
using RemoveRepeatedCharacters.TextParsers;
using System;
using RemoveRepeatedCharacters.TextParsers.Models;

namespace RemoveRepeatedCharacters;

class Program
{
    private const string TextToParse = "aaabbbcccbb";

    private static ParsedTextAndExecutionTime _forLoopRemoveRepeatedCharacters;
    private static ParsedTextAndExecutionTime _parallelForLoopRemoveRepeatedCharacters;
    private static ParsedTextAndExecutionTime _recursiveRemoveRepeatedCharacters;

    static void Main(string[] args)
    {
        var serviceCollection = IOC.Initialize();
        ProcessText(serviceCollection);

        Console.WriteLine($"ForLoop: Unparsed string {TextToParse} Result is {_forLoopRemoveRepeatedCharacters.ParsedText} and took {_forLoopRemoveRepeatedCharacters.ExecutionTime.Milliseconds} milliseconds");
        Console.WriteLine($"ParallelForLoop: Unparsed string {TextToParse} Result is {_parallelForLoopRemoveRepeatedCharacters.ParsedText} and took {_parallelForLoopRemoveRepeatedCharacters.ExecutionTime.Milliseconds} milliseconds");
        Console.WriteLine($"Recursive: Unparsed string {TextToParse} Result is {_recursiveRemoveRepeatedCharacters.ParsedText} and took {_recursiveRemoveRepeatedCharacters.ExecutionTime.Milliseconds} milliseconds");
        Console.ReadLine();
    }

    private static void ProcessText(IServiceProvider serviceCollection)
    {
        _forLoopRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => serviceCollection.GetService<ForLoopTextParser>().RemoveRepeatedCharacters(TextToParse), TextToParse);
        _parallelForLoopRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => serviceCollection.GetService<ParallelForLoopTextParser>().RemoveRepeatedCharacters(TextToParse), TextToParse);
        _recursiveRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => serviceCollection.GetService<RecursiveTextParser>().RemoveRepeatedCharacters(TextToParse), TextToParse);
    }

    private static ParsedTextAndExecutionTime RemoveRepeatedCharacters(Func<string, string> removeDuplicatesMethod, string textToParse)
    {
        var startTime = DateTime.Now;
        var parsedText = removeDuplicatesMethod(textToParse);
        var endTime = DateTime.Now;
        var totalTime = endTime - startTime;

        return new ParsedTextAndExecutionTime { ExecutionTime = totalTime, ParsedText = parsedText };
    }
}