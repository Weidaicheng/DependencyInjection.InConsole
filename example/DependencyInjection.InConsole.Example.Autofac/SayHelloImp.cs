namespace DependencyInjection.InConsole.Example.Autofac
{
    public class SayHelloImp : ISayHello
    {
        public string SayHello(string name)
        {
            return $"Hello {name}";
        }
    }
}