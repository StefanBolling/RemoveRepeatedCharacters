using Microsoft.Extensions.DependencyInjection;
using RemoveRepeatedCharachters.TextParsers;
using RemoveRepeatedCharachters.TextParsers.Models;
using System;

namespace RemoveRepeatedCharachters
{
    class Program
    {
        private const string textToParse = "aaabbbcccbb";

        private static ParsedTextAndExcecutionTime ForLoopRemoveRepeatedCharacters;
        private static ParsedTextAndExcecutionTime ParallelForLoopRemoveRepeatedCharacters;
        private static ParsedTextAndExcecutionTime RecursiveRemoveRepeatedCharacters;

        static void Main(string[] args)
        {
            var serviceCollection = IOC.Initialize();
            ProcessText(serviceCollection);

            Console.WriteLine($"ForLoop: Unparsed string {textToParse} Result is {ForLoopRemoveRepeatedCharacters.ParsedText} and took {ForLoopRemoveRepeatedCharacters.ExcecutionTime.Milliseconds} milliseconds");
            Console.WriteLine($"ParallelForLoop: Unparsed string {textToParse} Result is {ParallelForLoopRemoveRepeatedCharacters.ParsedText} and took {ParallelForLoopRemoveRepeatedCharacters.ExcecutionTime.Milliseconds} milliseconds");
            Console.WriteLine($"Recursive: Unparsed string {textToParse} Result is {RecursiveRemoveRepeatedCharacters.ParsedText} and took {RecursiveRemoveRepeatedCharacters.ExcecutionTime.Milliseconds} milliseconds");
            Console.ReadLine();
        }

        private static void ProcessText(ServiceProvider serviceCollection)
        {
            ForLoopRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => serviceCollection.GetService<ForLoopTextParser>().RemoveRepeatedCharacters(textToParse), textToParse);
            ParallelForLoopRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => serviceCollection.GetService<ParallelForLoopTextParser>().RemoveRepeatedCharacters(textToParse), textToParse);
            RecursiveRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => serviceCollection.GetService<RecursiveTextParser>().RemoveRepeatedCharacters(textToParse), textToParse);
        }

        private static ParsedTextAndExcecutionTime RemoveRepeatedCharacters(Func<string, string> removeDuplicatesMethod, string textToParse)
        {
            var startTime = DateTime.Now;
            var parsedText = removeDuplicatesMethod(textToParse);
            var endTime = DateTime.Now;
            var totalTime = endTime - startTime;

            return new ParsedTextAndExcecutionTime() { ExcecutionTime = totalTime, ParsedText = parsedText };
        }
    }
}