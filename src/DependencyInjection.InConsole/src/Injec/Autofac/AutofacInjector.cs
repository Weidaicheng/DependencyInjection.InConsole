using System;

namespace DependencyInjection.InConsole.Injec.Autofac
{
    /// <summary>
    /// <see cref="AutofacInjector" />
    /// </summary>
    public abstract class AutofacInjector
    {
        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <returns>Returns <see cref="IServiceProvider" /></returns>
        public abstract IServiceProvider Inject();
    }
}