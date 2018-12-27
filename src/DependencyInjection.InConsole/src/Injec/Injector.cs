using System;
using DependencyInjection.InConsole.Creations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Injec
{
    /// <summary>
    /// Abstract class contains an abstract Inject method and a final Build method
    /// </summary>
    public abstract class Injector
    {
        /// <summary>
        /// A readonly instance of <see cref="IServiceCollection" />
        /// </summary>
        protected IServiceCollection services { get; } = Singletons.Services;

        /// <summary>
        /// A readonly instance of <see cref="IConfiguration" />
        /// </summary>
        protected IConfiguration configuration { get; } = Singletons.Configuration;

        /// <summary>
        /// Inject dependencies
        /// </summary>
        public abstract void Inject();

        /// <summary>
        /// Build <see cref="IServiceProvider" />
        /// </summary>
        /// <returns>Returns <see cref="IServiceProvider" /></returns>
        public static IServiceProvider Build() => Singletons.Services.BuildServiceProvider();
    }
}