namespace DependencyInjection.InConsole.Injec.Generic
{
    /// <summary>
    /// Abstract generic class contains an abstract generic Inject 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Injector<T> : Injector
    {
        /// <summary>
        /// override and do nothing, and set as sealed
        /// </summary>
        public sealed override void Inject()
        {
            // do nothing
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="t"></param>
        public abstract void Inject(T t);
    }
    
    /// <summary>
    /// Abstract generic class contains an abstract generic Inject 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public abstract class Injector<T1, T2> : Injector
    {
        /// <summary>
        /// override and do nothing, and set as sealed
        /// </summary>
        public sealed override void Inject()
        {
            // do nothing
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        public abstract void Inject(T1 t1, T2 t2);
    }
    
    /// <summary>
    /// Abstract generic class contains an abstract generic Inject 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public abstract class Injector<T1, T2, T3> : Injector
    {
        /// <summary>
        /// override and do nothing, and set as sealed
        /// </summary>
        public sealed override void Inject()
        {
            // do nothing
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        public abstract void Inject(T1 t1, T2 t2, T3 t3);
    }
    
    /// <summary>
    /// Abstract generic class contains an abstract generic Inject 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public abstract class Injector<T1, T2, T3, T4> : Injector
    {
        /// <summary>
        /// override and do nothing, and set as sealed
        /// </summary>
        public sealed override void Inject()
        {
            // do nothing
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        /// <param name="t4"></param>
        public abstract void Inject(T1 t1, T2 t2, T3 t3, T4 t4);
    }
    
    /// <summary>
    /// Abstract generic class contains an abstract generic Inject 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    public abstract class Injector<T1, T2, T3, T4, T5> : Injector
    {
        /// <summary>
        /// override and do nothing, and set as sealed
        /// </summary>
        public sealed override void Inject()
        {
            // do nothing
        }

        /// <summary>
        /// Inject dependencies
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        /// <param name="t4"></param>
        /// <param name="t5"></param>
        public abstract void Inject(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
    }
}