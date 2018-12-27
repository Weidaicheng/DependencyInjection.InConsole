using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Injec
{
    /// <summary>
    /// <see cref="ConfigurationInjector" />
    /// </summary>
    public class ConfigurationInjector : Injector
    {
        public override void Inject()
        {
            services.AddSingleton<IConfiguration>(p => configuration);
        }
    }
}