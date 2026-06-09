using System.Text;
using System.Threading.Tasks;
using RemoveRepeatedCharacters.TextParsers.Interfaces;

namespace RemoveRepeatedCharacters.TextParsers;

public class ParallelForLoopTextParser : ITextParser
{
    public string Name => "ParallelForLoop";

    public string RemoveRepeatedCharacters(string stringToParse)
    {
        if (string.IsNullOrEmpty(stringToParse))
            return stringToParse;

        // Deciding whether to keep each character only depends on its neighbour,
        // so that decision can be made independently per index in parallel.
        // Each iteration writes to its own slot, so there is no shared-state race.
        var keep = new bool[stringToParse.Length];
        Parallel.For(0, stringToParse.Length, i =>
        {
            keep[i] = i == 0 || stringToParse[i] != stringToParse[i - 1];
        });

        // Assembling the result must happen in order, sequentially.
        var parsedString = new StringBuilder(stringToParse.Length);
        for (var i = 0; i < stringToParse.Length; i++)
        {
            if (keep[i])
                parsedString.Append(stringToParse[i]);
        }

        return parsedString.ToString();
    }
}
