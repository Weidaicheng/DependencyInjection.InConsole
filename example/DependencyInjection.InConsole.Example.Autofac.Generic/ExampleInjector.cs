using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DependencyInjection.InConsole.Injec.Autofac.Generic;

namespace DependencyInjection.InConsole.Example.Autofac.Generic
{
    public class ExampleInjector : AutofacInjector<string>
    {
        public override IServiceProvider Inject(string t)
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.RegisterType<FruitDisplay>().As<IFruitDisplay>();
            builder.RegisterType<FruitPresenter>().As<FruitPresenter>();
            builder.Register(context => new Fruit(t));
            var container = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }
    }

    public class ExampleAdapter : AutofacInjectorAdapter<string>
    {
        
    }
}