using System;

namespace DependencyInjection.InConsole.Injec.Autofac.Generic
{
    /// <summary>
    /// Autofac injector
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AutofacInjector<T> : AutofacInjector
    {
        public sealed override IServiceProvider Inject()
        {
            // do nothing
            return null;
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public abstract IServiceProvider Inject(T t);
    }
    
    /// <summary>
    /// Autofac injector
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public abstract class AutofacInjector<T1, T2> : AutofacInjector
    {
        public sealed override IServiceProvider Inject()
        {
            // do nothing
            return null;
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <returns></returns>
        public abstract IServiceProvider Inject(T1 t1, T2 t2);
    }

    /// <summary>
    /// Autofac injector
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public abstract class AutofacInjector<T1, T2, T3> : AutofacInjector
    {
        public sealed override IServiceProvider Inject()
        {
            // do nothing
            return null;
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <returns></returns>
        public abstract IServiceProvider Inject(T1 t1, T2 t2, T3 t3);
    }

    /// <summary>
    /// Autofac injector
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public abstract class AutofacInjector<T1, T2, T3, T4> : AutofacInjector
    {
        public sealed override IServiceProvider Inject()
        {
            // do nothing
            return null;
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <returns></returns>
        public abstract IServiceProvider Inject(T1 t1, T2 t2, T3 t3, T4 t4);
    }

    /// <summary>
    /// Autofac injector
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    public abstract class AutofacInjector<T1, T2, T3, T4, T5> : AutofacInjector
    {
        public sealed override IServiceProvider Inject()
        {
            // do nothing
            return null;
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <returns></returns>
        public abstract IServiceProvider Inject(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
    }
}