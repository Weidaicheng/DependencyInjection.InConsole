using System;
using System.Collections.Generic;

namespace DependencyInjection.InConsole.Types
{
    /// <summary>
    /// Factory for <see cref="ITypeProvider"/>
    /// </summary>
    public class TypeFactory
    {
        
#if DEBUG
        public Lazy<IEnumerable<Type>> _types;
#else
        private Lazy<IEnumerable<Type>> _types;
#endif

        /// <summary>
        /// Constructor for <see cref="TypeFactory"/>
        /// </summary>
        public TypeFactory()
        {
            _types = new Lazy<IEnumerable<Type>>((() => new TypeProvider().GetTypes()));
        }

        /// <summary>
        /// Get all types
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Type> GetTypes()
        {
            return _types.Value;
        }
    }
}