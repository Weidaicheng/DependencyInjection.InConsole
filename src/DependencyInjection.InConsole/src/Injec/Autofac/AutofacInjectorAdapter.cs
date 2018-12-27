using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.InConsole.Exceptions;
using DependencyInjection.InConsole.Types;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Injec.Autofac
{
    /// <summary>
    /// An adapter of <see cref="AutofacInjector" />
    /// </summary>
    public sealed class AutofacInjectorAdapter : Injector
    {
#if DEBUG
        public ITypeProvider _typeProvider;
#else
        private readonly ITypeProvider _typeProvider;
#endif

        /// <summary>
        /// Constructor of <see cref="AutofacInjectorAdapter" />
        /// </summary>
        public AutofacInjectorAdapter()
        {
            _typeProvider = new TypeProvider();
        }

        /// <summary>
        /// Get the one and the only (if it exists) instance of <see cref="AutofacInjector" />
        /// <param name="injector">Value will be null, if there isn't one</param>
        /// <returns>If there's an instance, will return true, otherwise false</returns>
        /// </summary>
        private bool getAutofacInjector(out AutofacInjector injector)
        {
            // get types
            var types = _typeProvider.GetTypes();
            // get implications of AutofacInjector
            var implications = types.Where(t => !t.IsAbstract && typeof(AutofacInjector).IsAssignableFrom(t));

            if (implications.Count() == 0)
            {
                injector = null;
                return false;
            }
            else if (implications.Count() > 1)
            {
                throw new MultiAutofacInjectorImplicationsException($"There are more than one implication of {nameof(AutofacInjector)}");
            }
            else // implication.Count() equals 1
            {
                // get an instance of AutofacInjector
                injector = (AutofacInjector)implications.First().Assembly.CreateInstance(implications.First().FullName);
                return true;
            }
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        public override void Inject()
        {
            if (getAutofacInjector(out AutofacInjector autofacInjector))
            {
                // get autofac provider
                var provider = autofacInjector.Inject();
                var types = _typeProvider.GetTypes(); // FIXME: improve the speed of get the types, maybe a cache is needed?

                Parallel.ForEach(types, type =>
                {
                    try
                    {
                        // get registered
                        var obj = provider.GetService(type);
                        // if registered
                        if (obj != null)
                        {
                            // register by Transient
                            services.AddTransient(type, p => obj);
                        }
                    }
                    catch (System.InvalidOperationException)
                    { }
                });
            }
        }
    }
}