using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DependencyInjection.InConsole.Injec.Autofac;

namespace DependencyInjection.InConsole.Example.Autofac
{
    public class ExampleInjector : AutofacInjector
    {
        public override IServiceProvider Inject()
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.RegisterType<SayHelloImp>().As<ISayHello>();
            builder.RegisterType<OutputHello>().As<OutputHello>();
            var container = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }
    }
}