﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Example.Autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = Startup.ConfigureServices();

            var configuration = provider.GetRequiredService<IConfiguration>();
            Console.WriteLine(configuration["foo"]);

            var o = provider.GetRequiredService<OutputHello>();
            o.Output("Weidaicheng");
        }
    }
}
