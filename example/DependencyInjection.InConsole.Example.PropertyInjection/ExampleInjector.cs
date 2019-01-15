using DependencyInjection.InConsole.Injec;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Example.PropertyInjection
{
    public class ExampleInjector : Injector
    {
        public override void Inject()
        {
            services.AddTransient<ISayHello, SayHelloImp>();
            services.AddTransient<OutputHello, OutputHello>();
        }
    }
}