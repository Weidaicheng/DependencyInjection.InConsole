using System;
using DependencyInjection.InConsole.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Creations
{
    /// <summary>
    /// Singletons
    /// </summary>
    internal static class Singletons
    {
        static Singletons()
        {
            Services = new ServiceCollection();
            Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true)
                    .Build();
        }

        /// <summary>
        /// Get an instance of <see cref="IServiceCollection"/>
        /// </summary>
        internal static IServiceCollection Services { get; }

        /// <summary>
        /// Get an instance of <see cref="IConfiguration"/>
        /// </summary>
        internal static IConfiguration Configuration { get; }

        /// <summary>
        /// Get or set an instance of <see cref="IServiceProvider"/>
        /// </summary>
        public static IServiceProvider Provider => Services.BuildServiceProvider();
    }
}