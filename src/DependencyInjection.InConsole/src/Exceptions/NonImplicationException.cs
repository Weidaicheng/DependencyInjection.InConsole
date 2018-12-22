using System;

namespace DependencyInjection.InConsole.Exceptions
{
    /// <summary>
    /// Non implication of an interface exception
    /// </summary>
    public class NonImplicationException : Exception
    {
        /// <summary>
        /// Non implication of an interface exception
        /// </summary>
        /// <param name="message">Exception message</param>
        public NonImplicationException(string message)
            : base(message)
        { }
    }
}