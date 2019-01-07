using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjection.InConsole.Exceptions;
using DependencyInjection.InConsole.Injec;

namespace DependencyInjection.InConsole.Types
{
    /// <summary>
    /// <see cref="InstanceCreator{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InstanceCreator<T> where T : Injector
    {
        /// <summary>
        /// Get types which implicit <see cref="T" />
        /// </summary>
        /// <returns>Returns collection of <see cref="Type" /></returns>
        public IEnumerable<Type> GetInjectorImpTypes(ITypeProvider typeProvider)
        {
            // Get an implication of IInject
            var types = typeProvider.GetTypes();
            var implications = types.Where(t => !t.IsAbstract && typeof(T).IsAssignableFrom(t));

            #region verify implication
            if (implications.Count() == 0)
            {
                throw new NonImplicationException($"Can't find one implication of {typeof(T).Name}.");
            }
            #endregion

            return implications;
        }

        /// <summary>
        /// Get an instance of <see cref="T" />
        /// </summary>
        /// <param name="injectorType">Type info</param>
        /// <returns>Returns <see cref="T" /></returns>
        public T GetInstance(Type injectorType) => (T)injectorType.Assembly.CreateInstance(injectorType.FullName);
    }
}