using System;
using DependencyInjection.InConsole.Injec.Autofac;

namespace DependencyInjection.InConsole.Exceptions
{
    /// <summary>
    /// multiple implications of <see cref="AutofacInjector" /> exception
    /// </summary>
    public class MultiAutofacInjectorImplicationsException : Exception
    {
        /// <summary>
        /// multiple implications of <see cref="AutofacInjector" /> exception
        /// </summary>
        /// <param name="message">Exception message</param>
        public MultiAutofacInjectorImplicationsException(string message)
            : base(message)
        { }
    }
}