using System;
using System.Collections.Generic;
using AspectInjector.Broker;
using DependencyInjection.InConsole.Attributes;

namespace DependencyInjection.InConsole.Example.PropertyInjection
{
    public class OutputHello
    {
        [Inject]
        public ISayHello SayHello { get; set; }

        public void Output(string name)
        {
            Console.WriteLine(SayHello.SayHello(name));
        }
    }
}