using System;
using System.Collections.Concurrent;
using AspectInjector.Broker;
using DependencyInjection.InConsole.Creations;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Attributes
{
    /// <summary>
    /// Attribute for property injection
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    [Aspect(Scope.Global)]
    [Injection(typeof(InjectAttribute))]
    public class InjectAttribute : Attribute
    {
        /// <summary>
        /// A container of injected types for property injection
        /// </summary>
        private readonly ConcurrentDictionary<string, object>
            _propertiesJar = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// if the key is in the jar
        /// </summary>
        /// <param name="key">the full name of a type</param>
        /// <returns></returns>
        private bool isInTheJar(string key)
        {
            return _propertiesJar.ContainsKey(key)
                   && _propertiesJar[key] != null;
        }

        /// <summary>
        /// Property enter
        /// </summary>
        /// <param name="rType"></param>
        /// <param name="name"></param>
        /// <param name="instance"></param>
        [Advice(Kind.Before, Targets = Target.Getter)]
        public void PropertyEnter([Argument(Source.ReturnType)] Type rType,
            [Argument(Source.Name)] string name,
            [Argument(Source.Instance)] object instance)
        {
            var key = rType.FullName;

            if (!isInTheJar(key))
            {
                // not set, set a value
                _propertiesJar[key] = Singletons.Provider.GetRequiredService(rType);
            }

            instance.GetType().GetProperty(name).SetValue(instance, _propertiesJar[key]);
        }
    }
}