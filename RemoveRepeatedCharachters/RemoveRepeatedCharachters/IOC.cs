using Microsoft.Extensions.DependencyInjection;
using RemoveRepeatedCharacters.TextParsers;
using RemoveRepeatedCharacters.TextParsers.Interfaces;

namespace RemoveRepeatedCharacters;

public static class IOC
{
    public static ServiceProvider Initialize()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddScoped<ITextParser, ForLoopTextParser>();
        serviceCollection.AddScoped<ITextParser, ParallelForLoopTextParser>();
        serviceCollection.AddScoped<ITextParser, RecursiveTextParser>();

        return serviceCollection.BuildServiceProvider();
    }
}
