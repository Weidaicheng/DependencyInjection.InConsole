using System;
using DependencyInjection.InConsole.Creations;
using DependencyInjection.InConsole.Injec;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // var provider = Startup.ConfigureServices();
            var provider = Singletons.Provider;

            var configuration = provider.GetRequiredService<IConfiguration>();
            Console.WriteLine(configuration["foo"]);

            var o = provider.GetRequiredService<OutputHello>();
            o.Output("Weidaicheng");
        }
    }
}
