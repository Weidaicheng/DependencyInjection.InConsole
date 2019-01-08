using System;
using System.Threading.Tasks;
using DependencyInjection.InConsole.Types;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InConsole.Injec.Autofac
{
    /// <summary>
    /// An adapter of <see cref="AutofacInjector" />
    /// </summary>
    public sealed class AutofacInjectorAdapter : Injector
    {
        private readonly AutofacInjectWorker _autofacInjectWorker;

        /// <summary>
        /// Constructor of <see cref="AutofacInjectorAdapter" />
        /// </summary>
        public AutofacInjectorAdapter()
        {
            _autofacInjectWorker = AutofacInjectWorkerFactory.GetWorker();
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        public override void Inject() =>
            _autofacInjectWorker.Inject<AutofacInjector>(services, injector => injector.Inject());
    }
}