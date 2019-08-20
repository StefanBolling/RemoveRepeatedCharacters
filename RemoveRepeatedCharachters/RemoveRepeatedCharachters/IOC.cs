using Microsoft.Extensions.DependencyInjection;
using RemoveRepeatedCharachters.TextParsers;

namespace RemoveRepeatedCharachters
{
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
}