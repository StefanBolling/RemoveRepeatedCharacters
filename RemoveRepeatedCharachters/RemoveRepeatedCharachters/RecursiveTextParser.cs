using System.Linq;

namespace RemoveRepeatedCharachters
{
    public class RecursiveTextParser : ITextParser
    {
        private string ParsedText;

        public string RemoveRepeatedCharacters(string stringToParse)
        {
            RemoveRepeatedCharactersInArray(stringToParse.ToArray());

            return ParsedText;
        }

        private void RemoveRepeatedCharactersInArray(char[] textArray)
        {
            if (textArray.Length == 1)
            {
                if (ParsedText.ToArray()[ParsedText.Length - 1] != textArray[0])
                    ParsedText += textArray[0];
                return;
            }
            else if (textArray[1] != textArray[0])
                ParsedText += textArray[0];

            RemoveRepeatedCharactersInArray(textArray.Skip(1).ToArray());
        }
    }
}