using System;
using DependencyInjection.InConsole.Creations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Injec
{
    public abstract class Injector
    {
        protected IServiceCollection services = Singletons.Services;
        protected IConfiguration configuration = Singletons.Configuration;

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="message">Exception message</param>
        public abstract void Inject();

        /// <summary>
        /// Build <see cref="IServiceProvider" />
        /// </summary>
        /// <returns>Returns <see cref="IServiceProvider" /></returns>
        public static IServiceProvider Build() => Singletons.Services.BuildServiceProvider();
    }
}