using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Creations
{
    /// <summary>
    /// Singletons
    /// </summary>
    internal static class Singletons
    {
        private static IServiceCollection _services;
        private static IConfiguration _configuration;

        static Singletons()
        {
            _services = new ServiceCollection();
            _configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true)
                    .Build();
        }

        /// <summary>
        /// Get an instance of <see cref="IServiceCollection"/>
        /// </summary>
        internal static IServiceCollection Services
        {
            get
            {
                return _services;
            }
        }

        /// <summary>
        /// Get an instance of <see cref="IConfiguration"/>
        /// </summary>
        internal static IConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
        }
    }
}