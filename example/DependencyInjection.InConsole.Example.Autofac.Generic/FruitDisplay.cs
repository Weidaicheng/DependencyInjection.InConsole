using System;

namespace DependencyInjection.InConsole.Example.Autofac.Generic
{
    public class FruitDisplay : IFruitDisplay
    {
        private readonly Fruit _fruit;

        public FruitDisplay(Fruit fruit)
        {
            _fruit = fruit;
        }
        
        public void Display()
        {
            Console.WriteLine(_fruit.Name);
        }
    }
}