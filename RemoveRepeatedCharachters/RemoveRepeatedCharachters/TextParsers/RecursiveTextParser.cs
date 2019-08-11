using RemoveRepeatedCharachters.TextParsers.Interfaces;
using System.Linq;

namespace RemoveRepeatedCharachters.TextParsers
{
    public class RecursiveTextParser : ITextParser
    {
        private string parsedText;

        public string RemoveRepeatedCharacters(string stringToParse)
        {
            RemoveRepeatedCharactersInArray(stringToParse.ToArray());

            return parsedText;
        }

        private void RemoveRepeatedCharactersInArray(char[] textArray)
        {
            if (textArray.Length == 1)
            {
                if (parsedText.ToArray()[parsedText.Length - 1] != textArray[0])
                    parsedText += textArray[0];
                return;
            }
            else if (textArray[1] != textArray[0])
                parsedText += textArray[0];

            RemoveRepeatedCharactersInArray(textArray.Skip(1).ToArray());
        }
    }
}