namespace RemoveRepeatedCharacters.TextParsers.Interfaces;

public interface ITextParser
{
    /// <summary>
    /// Human-readable name of the parsing strategy, used when reporting results.
    /// </summary>
    string Name { get; }

    string RemoveRepeatedCharacters(string stringToParse);
}
