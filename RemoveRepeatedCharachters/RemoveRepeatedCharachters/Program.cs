using RemoveRepeatedCharachters.TextParsers;
using System;

namespace RemoveRepeatedCharachters
{
    class Program
    {
        private const string TextToParse = "aaabbbcccbb";

        private static readonly ForLoopTextParser forLoopTextParser = IOC.container.GetInstance<ForLoopTextParser>();
        private static readonly ParallelForLoopTextParser parallelForLoopTextParser = IOC.container.GetInstance<ParallelForLoopTextParser>();
        private static readonly RecursiveTextParser recursiveTextParser = IOC.container.GetInstance<RecursiveTextParser>();

        static void Main(string[] args)
        {
            IOC.ConfigureIOC();
            var forLoopRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => forLoopTextParser.RemoveRepeatedCharacters(TextToParse), TextToParse);
            var parallelForLoopRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => parallelForLoopTextParser.RemoveRepeatedCharacters(TextToParse), TextToParse);
            var recursiveRemoveRepeatedCharacters = RemoveRepeatedCharacters(x => recursiveTextParser.RemoveRepeatedCharacters(TextToParse), TextToParse);

            Console.WriteLine($"ForLoop: Unparsed string {TextToParse} Result is {forLoopRemoveRepeatedCharacters.Item2} and took {forLoopRemoveRepeatedCharacters.Item1.Milliseconds} milliseconds");
            Console.WriteLine($"ParallelForLoop: Unparsed string {TextToParse} Result is {parallelForLoopRemoveRepeatedCharacters.Item2} and took {parallelForLoopRemoveRepeatedCharacters.Item1.Milliseconds} milliseconds");
            Console.WriteLine($"Recursive: Unparsed string {TextToParse} Result is {recursiveRemoveRepeatedCharacters.Item2} and took {recursiveRemoveRepeatedCharacters.Item1.Milliseconds} milliseconds");
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