#if NETCOREAPP2_2
using DependencyInjection.InConsole;
using DependencyInjection.InConsole.Creations;

internal class StartupHook
{
    public static void Initialize()
    {
        Singletons.Provider = Startup.ConfigureServices();
    }
}
#endif