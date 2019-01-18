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
        /// <param name="typeFactory"><see cref="TypeFactory"/></param>
        /// <returns>Returns collection of <see cref="Type" /></returns>
        public IEnumerable<Type> GetInjectorImpTypes(TypeFactory typeFactory)
        {
            // Get an implication of IInject
            var types = typeFactory.GetTypes();
            var implications = types.Where(t => !t.IsAbstract && typeof(T).IsAssignableFrom(t));

            #region verify implication
            if (!implications.Any())
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
        /// <param name="instance"></param>
        /// <returns>if get instance success</returns>
        public bool GetInstance(Type injectorType, out T instance)
        {
            try
            {
                instance = (T) injectorType.Assembly.CreateInstance(injectorType.FullName);
                return true;
            }
            catch
            {
                instance = null;
                return false;
            }
        }
    }
}