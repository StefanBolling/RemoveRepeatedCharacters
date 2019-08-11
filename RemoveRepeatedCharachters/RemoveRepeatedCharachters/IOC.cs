using RemoveRepeatedCharachters.TextParsers;
using SimpleInjector;

namespace RemoveRepeatedCharachters
{
    public static class IOC
    {
        public static  Container container;

        public static void ConfigureIOC()
        {
            container = new Container();
            container.Register<ForLoopTextParser>();
            container.Register<ParallelForLoopTextParser>();
            container.Register<RecursiveTextParser>();

            container.Verify();
        }
    }
}
