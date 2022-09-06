using Microsoft.Extensions.DependencyInjection;
using RemoveRepeatedCharacters.TextParsers;

namespace RemoveRepeatedCharacters;

public static class IOC
{
    public static ServiceProvider Initialize()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddScoped<ForLoopTextParser, ForLoopTextParser>();
        serviceCollection.AddScoped<ParallelForLoopTextParser, ParallelForLoopTextParser>();
        serviceCollection.AddScoped<RecursiveTextParser, RecursiveTextParser>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        return serviceProvider;
    }
}