using DependencyInjection.InConsole.Injec.Generic;

namespace DependencyInjection.InConsole.Injec.Autofac.Generic
{
    /// <summary>
    /// An adapter of <see cref="AutofacInjector{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AutofacInjectorAdapter<T> : Injector<T>
    {
        private readonly AutofacInjectWorker _autofacInjectWorker;

        /// <summary>
        /// Constructor of <see cref="AutofacInjector{T}" />
        /// </summary>
        public AutofacInjectorAdapter()
        {
            _autofacInjectWorker = AutofacInjectWorkerFactory.GetWorker();
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="t"></param>
        public sealed override void Inject(T t) =>
            _autofacInjectWorker.Inject<AutofacInjector<T>>(services, injector => injector.Inject(t));
    }

    /// <summary>
    /// An adapter of <see cref="AutofacInjector{T1, T2}"/>
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class AutofacInjectorAdapter<T1, T2> : Injector<T1, T2>
    {
        private readonly AutofacInjectWorker _autofacInjectWorker;

        /// <summary>
        /// Constructor of <see cref="AutofacInjector{T1, T2}" />
        /// </summary>
        public AutofacInjectorAdapter()
        {
            _autofacInjectWorker = AutofacInjectWorkerFactory.GetWorker();
        }


        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        public sealed override void Inject(T1 t1, T2 t2) =>
            _autofacInjectWorker.Inject<AutofacInjector<T1, T2>>(services, injector => injector.Inject(t1, t2));
    }

    /// <summary>
    /// An adapter of <see cref="AutofacInjector{T1, T2, T3}"/>
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public class AutofacInjectorAdapter<T1, T2, T3> : Injector<T1, T2, T3>
    {
        private readonly AutofacInjectWorker _autofacInjectWorker;

        /// <summary>
        /// Constructor of <see cref="AutofacInjector{T1, T2, T3}" />
        /// </summary>
        public AutofacInjectorAdapter()
        {
            _autofacInjectWorker = AutofacInjectWorkerFactory.GetWorker();
        }


        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        public sealed override void Inject(T1 t1, T2 t2, T3 t3) =>
            _autofacInjectWorker.Inject<AutofacInjector<T1, T2, T3>>(services, injector => injector.Inject(t1, t2, t3));
    }

    /// <summary>
    /// An adapter of <see cref="AutofacInjector{T1, T2, T3, T4}"/>
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public class AutofacInjectorAdapter<T1, T2, T3, T4> : Injector<T1, T2, T3, T4>
    {
        private readonly AutofacInjectWorker _autofacInjectWorker;

        /// <summary>
        /// Constructor of <see cref="AutofacInjector{T1, T2, T3, T4}" />
        /// </summary>
        public AutofacInjectorAdapter()
        {
            _autofacInjectWorker = AutofacInjectWorkerFactory.GetWorker();
        }


        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        /// <param name="t4"></param>
        public sealed override void Inject(T1 t1, T2 t2, T3 t3, T4 t4) =>
            _autofacInjectWorker.Inject<AutofacInjector<T1, T2, T3, T4>>(services,
                injector => injector.Inject(t1, t2, t3, t4));
    }

    /// <summary>
    /// An adapter of <see cref="AutofacInjector{T1, T2, T3, T4, T5}"/>
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    public class AutofacInjectorAdapter<T1, T2, T3, T4, T5> : Injector<T1, T2, T3, T4, T5>
    {
        private readonly AutofacInjectWorker _autofacInjectWorker;

        /// <summary>
        /// Constructor of <see cref="AutofacInjector{T1, T2, T3, T4, T5}" />
        /// </summary>
        public AutofacInjectorAdapter()
        {
            _autofacInjectWorker = AutofacInjectWorkerFactory.GetWorker();
        }


        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        /// <param name="t4"></param>
        /// <param name="t5"></param>
        public sealed override void Inject(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) =>
            _autofacInjectWorker.Inject<AutofacInjector<T1, T2, T3, T4, T5>>(services,
                injector => injector.Inject(t1, t2, t3, t4, t5));
    }
}