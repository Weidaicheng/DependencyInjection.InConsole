using System;
using DependencyInjection.InConsole.Types;
using DependencyInjection.InConsole.Injec;
using DependencyInjection.InConsole.Injec.Generic;

namespace DependencyInjection.InConsole
{
    /// <summary>
    /// Entry point
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// do the inject job
        /// </summary>
        /// <param name="inject">specific injection operation</param>
        /// <typeparam name="T">generic or non-generic <see cref="Injector"/></typeparam>
        /// <returns></returns>
        private static IServiceProvider configureServices<T>(Action<T> inject) where T : Injector
        {
            var typeFactory = new TypeFactory();
            var creator = new InstanceCreator<T>();
            foreach (var type in creator.GetInjectorImpTypes(typeFactory))
            {
                if (creator.GetInstance(type, out var injector))
                    inject(injector);
            }

            return Injector.Build();
        }

        /// <summary>
        /// Inject types
        /// </summary>
        /// <returns>Returns <see cref="IServiceProvider" /></returns>
        public static IServiceProvider ConfigureServices()
        {
            return configureServices<Injector>(injector => injector.Inject());
        }

        /// <summary>
        /// Inject types
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IServiceProvider ConfigureServices<T>(T t)
        {
            return configureServices<Injector<T>>(injector => injector.Inject(t));
        }

        /// <summary>
        /// Inject types
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static IServiceProvider ConfigureServices<T1, T2>(T1 t1, T2 t2)
        {
            return configureServices<Injector<T1, T2>>(injector => injector.Inject(t1, t2));
        }

        /// <summary>
        /// Inject types
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static IServiceProvider ConfigureServices<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
        {
            return configureServices<Injector<T1, T2, T3>>(injector => injector.Inject(t1, t2, t3));
        }

        /// <summary>
        /// Inject types
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        /// <param name="t4"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static IServiceProvider ConfigureServices<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return configureServices<Injector<T1, T2, T3, T4>>(injector => injector.Inject(t1, t2, t3, t4));
        }

        /// <summary>
        /// Inject types
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        /// <param name="t4"></param>
        /// <param name="t5"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        public static IServiceProvider ConfigureServices<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return configureServices<Injector<T1, T2, T3, T4, T5>>(injector => injector.Inject(t1, t2, t3, t4, t5));
        }
    }
}