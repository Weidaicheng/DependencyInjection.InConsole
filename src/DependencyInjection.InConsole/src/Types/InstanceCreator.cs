using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjection.InConsole.Exceptions;
using DependencyInjection.InConsole.Injec;

namespace DependencyInjection.InConsole.Types
{
    public class InstanceCreator
    {
        public IEnumerable<Type> GetInjectorImpTypes(ITypeProvider typeProvider)
        {
            // Get an implication of IInject
            var types = typeProvider.GetTypes();
            var implications = types.Where(t => !t.IsAbstract && typeof(Injector).IsAssignableFrom(t));

            #region verify implication
            if (implications.Count() == 0)
            {
                throw new NonImplicationException($"Can't find one implication of {typeof(Injector).Name}.");
            }
            #endregion

            return implications;
        }

        public Injector GetInstance(Type injectorType) => (Injector)injectorType.Assembly.CreateInstance(injectorType.FullName);
    }
}