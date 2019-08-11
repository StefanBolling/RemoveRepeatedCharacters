using RemoveRepeatedCharachters.TextParsers;
using System;

namespace RemoveRepeatedCharachters
{
    class Program
    {
        private const string textToParse = "aaabbbcccbb";

        private static readonly ForLoopTextParser forLoopTextParser = IOC.container.GetInstance<ForLoopTextParser>();
        private static readonly ParallelForLoopTextParser parallelForLoopTextParser = IOC.container.GetInstance<ParallelForLoopTextParser>();
        private static readonly RecursiveTextParser recursiveTextParser = IOC.container.GetInstance<RecursiveTextParser>();

        static void Main(string[] args)
        {
            IOC.ConfigureIOC();
            var forLoopRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => forLoopTextParser.RemoveRepeatedCharacters(textToParse), textToParse);
            var parallelForLoopRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => parallelForLoopTextParser.RemoveRepeatedCharacters(textToParse), textToParse);
            var recursiveRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => recursiveTextParser.RemoveRepeatedCharacters(textToParse), textToParse);

            Console.WriteLine($"ForLoop: Unparsed string {textToParse} Result is {forLoopRemoveRepeatedCharacters.Item2} and took {forLoopRemoveRepeatedCharacters.Item1.Milliseconds} milliseconds");
            Console.WriteLine($"ParallelForLoop: Unparsed string {textToParse} Result is {parallelForLoopRemoveRepeatedCharacters.Item2} and took {parallelForLoopRemoveRepeatedCharacters.Item1.Milliseconds} milliseconds");
            Console.WriteLine($"Recursive: Unparsed string {textToParse} Result is {recursiveRemoveRepeatedCharacters.Item2} and took {recursiveRemoveRepeatedCharacters.Item1.Milliseconds} milliseconds");
            Console.ReadLine();
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