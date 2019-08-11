using RemoveRepeatedCharachters.TextParsers.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace RemoveRepeatedCharachters.TextParsers
{
    public class ParallelForLoopTextParser : ITextParser
    {
        public string RemoveRepeatedCharacters(string stringToParse)
        {
            var textArray = stringToParse.ToArray();
            var parsedString = string.Empty;
            var arrayLength = textArray.Length;

            Parallel.For(0, arrayLength, i =>
            {
                if (i == 0)
                    parsedString += textArray[0];
                else if (textArray[i] != textArray[i - 1])
                    parsedString += textArray[i];
            });

            return parsedString;
        }
    }
}
