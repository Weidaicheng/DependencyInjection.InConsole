namespace DependencyInjection.InConsole.Example
{
    public class SayHelloImp : ISayHello
    {
        public string SayHello(string name)
        {
            return $"Hello {name}";
        }
    }
}