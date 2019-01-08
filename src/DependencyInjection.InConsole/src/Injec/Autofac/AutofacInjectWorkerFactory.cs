namespace DependencyInjection.InConsole.Injec.Autofac
{
    /// <summary>
    /// Factory for <see cref="AutofacInjectWorker"/>
    /// </summary>
    public class AutofacInjectWorkerFactory
    {
        /// <summary>
        /// get an instance of <see cref="AutofacInjectWorker"/>
        /// </summary>
        /// <returns></returns>
        public static AutofacInjectWorker GetWorker()
        {
            return new AutofacInjectWorker();
        }
    }
}