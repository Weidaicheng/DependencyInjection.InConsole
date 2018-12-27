using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DependencyInjection.InConsole.Exceptions;
using DependencyInjection.InConsole.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DependencyInjection.InConsole.Injec;

namespace DependencyInjection.InConsole
{
    /// <summary>
    /// Entry point
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Inject types
        /// </summary>
        /// <returns>Returns <see cref="IServiceProvider" /></returns>
        public static IServiceProvider ConfigureServices()
        {
            ITypeProvider typeProvider = new TypeProvider();
            var creator = new InstanceCreator();
            foreach (var t in creator.GetInjectorImpTypes(typeProvider))
            {
                var injector = creator.GetInstance(t);
                injector.Inject();
            }

            return Injector.Build();
        }
    }
}
