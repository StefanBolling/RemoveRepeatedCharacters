using System;

namespace RemoveRepeatedCharacters.TextParsers.Models;

public class ParsedTextAndExecutionTime
{
    public TimeSpan ExecutionTime { get; set; }

    public string ParsedText { get; set; }
}