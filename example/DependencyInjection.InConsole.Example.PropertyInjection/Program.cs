using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Example.PropertyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = Startup.ConfigureServices();

            var o = provider.GetRequiredService<OutputHello>();
            o.Output("Weidaicheng");
        }
    }
}