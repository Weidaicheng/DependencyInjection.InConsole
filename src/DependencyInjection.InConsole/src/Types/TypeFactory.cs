using System;
using System.Collections.Generic;

namespace DependencyInjection.InConsole.Types
{
    /// <summary>
    /// Factory for <see cref="ITypeProvider"/>
    /// </summary>
    public class TypeFactory
    {
        private IEnumerable<Type> _types;
#if DEBUG
        public ITypeProvider _typeProvider;
#else
        private readonly ITypeProvider _typeProvider;
#endif
        private static readonly object Locker = new object();

        /// <summary>
        /// Constructor for <see cref="TypeFactory"/>
        /// </summary>
        public TypeFactory()
        {
            _types = null;
            _typeProvider = new TypeProvider();
        }

        /// <summary>
        /// Get all types
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Type> GetTypes()
        {
            if (_types == null)
            {
                lock (Locker)
                {
                    if (_types == null)
                    {
                        _types = _typeProvider.GetTypes();
                    }
                }
            }

            return _types;
        }
    }
}