using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection.InConsole.Types
{
    public class TypeProvider : ITypeProvider
    {
        public IEnumerable<Type> GetTypes()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(assembly => assembly.GetTypes());

            return types;
        }
    }
}