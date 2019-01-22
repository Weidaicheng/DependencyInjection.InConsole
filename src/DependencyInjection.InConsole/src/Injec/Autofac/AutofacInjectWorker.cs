using System;
using System.Threading.Tasks;
using DependencyInjection.InConsole.Types;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Injec.Autofac
{
    /// <summary>
    /// Do the real inject works
    /// </summary>
    public class AutofacInjectWorker
    {
        private readonly TypeFactory _typeFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        public AutofacInjectWorker(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        /// <summary>
        /// inject
        /// </summary>
        /// <param name="services"></param>
        /// <param name="inject"></param>
        /// <typeparam name="T"></typeparam>
        public void Inject<T>(IServiceCollection services, Func<T, IServiceProvider> inject) where T : AutofacInjector
        {
            var creator = new AutofacInstanceCreator<T>();
            if (!creator.GetInjectorImpTypes(_typeFactory, out var autofacInjector)) return;
            // get autofac provider
            var provider = inject(autofacInjector);
            var types = _typeFactory.GetTypes();

            Parallel.ForEach(types, new ParallelOptions() {MaxDegreeOfParallelism = Environment.ProcessorCount }, type =>
            {
                object obj = null;
                try
                {
                    // get registered
                    obj = provider.GetService(type);
                }
                catch (InvalidOperationException) // TODO: find a way that don't use a try-catch block.
                { }
                    
                if (obj != null) // if registered
                {
                    // register by Transient
                    services.AddTransient(type, p => obj);
                }
            });
        }
    }
}