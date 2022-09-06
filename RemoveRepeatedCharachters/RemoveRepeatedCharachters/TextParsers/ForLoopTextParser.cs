using System.Linq;
using RemoveRepeatedCharacters.TextParsers.Interfaces;

namespace RemoveRepeatedCharacters.TextParsers;

public class ForLoopTextParser : ITextParser
{
    public string RemoveRepeatedCharacters(string stringToParse)
    {
        var textArray = stringToParse.ToArray();
        var parsedString = string.Empty;
        var arrayLength = textArray.Length;

        for (var i = 0; i < arrayLength; i++)
        {
            if (i == 0)
                parsedString += textArray[0];
            else if (textArray[i] != textArray[i - 1])
                parsedString += textArray[i];
        }

        return parsedString;
    }
}