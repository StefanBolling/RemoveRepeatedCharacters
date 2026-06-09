using System.Text;
using RemoveRepeatedCharacters.TextParsers.Interfaces;

namespace RemoveRepeatedCharacters.TextParsers;

public class RecursiveTextParser : ITextParser
{
    public string Name => "Recursive";

    public string RemoveRepeatedCharacters(string stringToParse)
    {
        if (string.IsNullOrEmpty(stringToParse))
            return stringToParse;

        var parsedString = new StringBuilder(stringToParse.Length);
        Append(stringToParse, 0, parsedString);

        return parsedString.ToString();
    }

    private static void Append(string source, int index, StringBuilder parsedString)
    {
        if (index >= source.Length)
            return;

        if (index == 0 || source[index] != source[index - 1])
            parsedString.Append(source[index]);

        Append(source, index + 1, parsedString);
    }
}
