using System;
using System.Collections.Generic;

namespace DependencyInjection.InConsole.Types
{
    public interface ITypeProvider
    {
        /// <summary>
        /// Get all types
        /// </summary>
        /// <returns>Returns collection of <see cref="Type" /></returns>
        IEnumerable<Type> GetTypes();
    }
}