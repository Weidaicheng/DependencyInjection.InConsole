using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjection.InConsole.Exceptions;
using DependencyInjection.InConsole.Injec;

namespace DependencyInjection.InConsole.Types
{
    /// <summary>
    /// <see cref="InstanceCreator" />
    /// </summary>
    public class InstanceCreator
    {
        /// <summary>
        /// Get types which implicit <see cref="Injector" />
        /// </summary>
        /// <returns>Returns collection of <see cref="Type" /></returns>
        public IEnumerable<Type> GetInjectorImpTypes(ITypeProvider typeProvider)
        {
            // Get an implication of IInject
            var types = typeProvider.GetTypes();
            var implications = types.Where(t => !t.IsAbstract && typeof(Injector).IsAssignableFrom(t));

            #region verify implication
            if (implications.Count() == 0)
            {
                throw new NonImplicationException($"Can't find one implication of {typeof(Injector).Name}.");
            }
            #endregion

            return implications;
        }

        /// <summary>
        /// Get an instance of <see cref="Injector" />
        /// </summary>
        /// <param name="injectorType">Type info</param>
        /// <returns>Returns <see cref="Injector" /></returns>
        public Injector GetInstance(Type injectorType) => (Injector)injectorType.Assembly.CreateInstance(injectorType.FullName);
    }
}