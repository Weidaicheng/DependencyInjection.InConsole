namespace DependencyInjection.InConsole.Example.Autofac.Generic
{
    public class Fruit
    {
        public Fruit(string name)
        {
            Name = name;
        }
        
        public string Name { get; set; }
    }
}