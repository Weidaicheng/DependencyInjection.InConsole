using DependencyInjection.InConsole.Exceptions;
using System.Linq;
using DependencyInjection.InConsole.Injec.Autofac;

namespace DependencyInjection.InConsole.Types
{
    /// <summary>
    /// <see cref="AutofacInstanceCreator{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AutofacInstanceCreator<T> where T : AutofacInjector
    {
        /// <summary>
        /// Get an instance of <see cref="T"/>
        /// </summary>
        /// <param name="typeProvider"></param>
        /// <param name="instance">the instance of <see cref="T"/></param>
        /// <returns>if successful got an instance</returns>
        /// <exception cref="MultiAutofacInjectorImplicationsException">Only one implication is allowed</exception>
        public bool GetInjectorImpTypes(ITypeProvider typeProvider, out T instance)
        {
            // get types
            var types = typeProvider.GetTypes();
            // get implications of T
            var implications = types.Where(t => !t.IsAbstract && typeof(T).IsAssignableFrom(t));

            if (!implications.Any())
            {
                instance = null;
                return false;
            }
            else if (implications.Count() > 1)
            {
                throw new MultiAutofacInjectorImplicationsException($"There are more than one implication of {nameof(T)}");
            }
            else // implication.Count() equals 1
            {
                // get an instance of T
                instance = (T) implications.First().Assembly.CreateInstance(implications.First().FullName);
                return true;
            }
        }
    }
}