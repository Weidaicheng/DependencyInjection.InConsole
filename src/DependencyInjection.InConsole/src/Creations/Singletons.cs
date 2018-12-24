using System;
using DependencyInjection.InConsole.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Creations
{
    /// <summary>
    /// Singletons
    /// </summary>
    public static class Singletons
    {
        private static IServiceCollection _services;
        private static IConfiguration _configuration;
#if NETCOREAPP2_2
        private static IServiceProvider _provider;
        private static bool _providerSet;
#endif        

        static Singletons()
        {
            _services = new ServiceCollection();
            _configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true)
                    .Build();
#if NETCOREAPP2_2
            _provider = null;
            _providerSet = false;
#endif            
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

#if NETCOREAPP2_2
        /// <summary>
        /// Get or set an instance of <see cref="IServiceProvider"/>
        /// </summary>
        public static IServiceProvider Provider 
        { 
            get
            {
                if(!_providerSet)
                {
                    throw new ProviderValueNotSetException("Provider didn't set a value.");
                }
                return _provider;
            }
            set
            {
                if(_providerSet)
                {
                    throw new ProviderValueAlreadySetException("Provider has already set.");
                }

                _provider = value;
            }
        }
#endif        
    }
}