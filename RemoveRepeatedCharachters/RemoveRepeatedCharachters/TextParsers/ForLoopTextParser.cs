using System.Text;
using RemoveRepeatedCharacters.TextParsers.Interfaces;

namespace RemoveRepeatedCharacters.TextParsers;

public class ForLoopTextParser : ITextParser
{
    public string Name => "ForLoop";

    public string RemoveRepeatedCharacters(string stringToParse)
    {
        if (string.IsNullOrEmpty(stringToParse))
            return stringToParse;

        var parsedString = new StringBuilder(stringToParse.Length);

        for (var i = 0; i < stringToParse.Length; i++)
        {
            if (i == 0 || stringToParse[i] != stringToParse[i - 1])
                parsedString.Append(stringToParse[i]);
        }

        return parsedString.ToString();
    }
}
