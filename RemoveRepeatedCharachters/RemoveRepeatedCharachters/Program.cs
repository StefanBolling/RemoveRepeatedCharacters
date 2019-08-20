using Microsoft.Extensions.DependencyInjection;
using RemoveRepeatedCharachters.TextParsers;
using System;

namespace RemoveRepeatedCharachters
{
    class Program
    {
        private const string textToParse = "aaabbbcccbb";

        private static Tuple<TimeSpan, string> ForLoopRemoveRepeatedCharacters { get; set; }
        private static Tuple<TimeSpan, string> ParallelForLoopRemoveRepeatedCharacters { get; set; }
        private static Tuple<TimeSpan, string> RecursiveRemoveRepeatedCharacters { get; set; }

        static void Main(string[] args)
        {
            var serviceCollection = IOC.Initialize();
            ProcessText(serviceCollection);

            Console.WriteLine($"ForLoop: Unparsed string {textToParse} Result is {ForLoopRemoveRepeatedCharacters.Item2} and took {ForLoopRemoveRepeatedCharacters.Item1.Milliseconds} milliseconds");
            Console.WriteLine($"ParallelForLoop: Unparsed string {textToParse} Result is {ParallelForLoopRemoveRepeatedCharacters.Item2} and took {ParallelForLoopRemoveRepeatedCharacters.Item1.Milliseconds} milliseconds");
            Console.WriteLine($"Recursive: Unparsed string {textToParse} Result is {RecursiveRemoveRepeatedCharacters.Item2} and took {RecursiveRemoveRepeatedCharacters.Item1.Milliseconds} milliseconds");
            Console.ReadLine();
        }

        private static void ProcessText(ServiceProvider serviceCollection)
        {
            ForLoopRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => serviceCollection.GetService<ForLoopTextParser>().RemoveRepeatedCharacters(textToParse), textToParse);
            ParallelForLoopRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => serviceCollection.GetService<ParallelForLoopTextParser>().RemoveRepeatedCharacters(textToParse), textToParse);
            RecursiveRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => serviceCollection.GetService<RecursiveTextParser>().RemoveRepeatedCharacters(textToParse), textToParse);
        }

        private static Tuple<TimeSpan, string> RemoveRepeatedCharacters(Func<string, string> removeDuplicatesMethod, string textToParse)
        {
            var startTime = DateTime.Now;
            var parsedString = removeDuplicatesMethod(textToParse);
            var endTime = DateTime.Now;
            var totalTime = endTime - startTime;

            return new Tuple<TimeSpan, string>(totalTime, parsedString);
        }
    }
}