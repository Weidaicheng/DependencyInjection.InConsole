using DependencyInjection.InConsole.Injec.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Example.Generic
{
    public class ExampleInjector : Injector<string>
    {
        public override void Inject(string t)
        {
            services.AddTransient<IFruitDisplay, FruitDisplay>();
            services.AddTransient<FruitPresenter, FruitPresenter>();
            services.AddTransient<Fruit>(provider => new Fruit(t));
        }
    }
}