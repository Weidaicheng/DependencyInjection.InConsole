using System;

namespace DependencyInjection.InConsole.Example
{
    public class OutputHello
    {
        private ISayHello _sayHello;

        public OutputHello(ISayHello sayHello)
        {
            _sayHello = sayHello;
        }

        public void Output(string name)
        {
            Console.WriteLine(_sayHello.SayHello(name));
        }
    }
}