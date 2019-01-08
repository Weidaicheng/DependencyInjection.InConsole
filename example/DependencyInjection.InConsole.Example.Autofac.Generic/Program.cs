using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Example.Autofac.Generic
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