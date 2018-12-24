#if NETCOREAPP2_2
using System;

namespace DependencyInjection.InConsole.Exceptions
{
    /// <summary>
    /// Provider value has already set exception
    /// </summary>
    public class ProviderValueAlreadySetException : Exception
    {
        /// <summary>
        /// Provider value has already set exception
        /// </summary>
        /// <param name="message">Exception message</param>
        public ProviderValueAlreadySetException(string message)
            : base(message)
        { }
    }
}
#endif