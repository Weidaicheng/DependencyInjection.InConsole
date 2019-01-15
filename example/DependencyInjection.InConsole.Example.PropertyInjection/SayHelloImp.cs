namespace DependencyInjection.InConsole.Example.PropertyInjection
{
    public class SayHelloImp : ISayHello
    {
        public string SayHello(string name)
        {
            return $"Hello {name}";
        }
    }
}