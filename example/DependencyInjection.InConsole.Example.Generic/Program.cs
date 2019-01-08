using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Example.Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = Startup.ConfigureServices("Apple");
            var presenter = provider.GetRequiredService<FruitPresenter>();
            presenter.Present();
        }
    }
}