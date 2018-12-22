using System;

namespace DependencyInjection.InConsole.Exceptions
{
    /// <summary>
    /// Non ctor of an implication exception
    /// </summary>
    public class NonCtorException : Exception
    {
        /// <summary>
        /// Non ctor of an implication exception
        /// </summary>
        /// <param name="message">Exception message</param>
        public NonCtorException(string message)
            : base(message)
        { }
    }
}