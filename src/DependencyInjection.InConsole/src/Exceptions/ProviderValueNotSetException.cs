#if NETCOREAPP2_2
using System;

namespace DependencyInjection.InConsole.Exceptions
{
    /// <summary>
    /// Provider value didn't set exception
    /// </summary>
    public class ProviderValueNotSetException : Exception
    {
        /// <summary>
        /// Provider value didn't set exception
        /// </summary>
        /// <param name="message">Exception message</param>
        public ProviderValueNotSetException(string message)
            : base(message)
        { }
    }
}
#endif