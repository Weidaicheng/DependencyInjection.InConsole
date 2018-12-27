using System;
using System.Collections.Generic;
using DependencyInjection.InConsole.Exceptions;
using DependencyInjection.InConsole.Injec.Autofac;
using DependencyInjection.InConsole.Types;
using NSubstitute;
using NUnit.Framework;

namespace DependencyInjection.InConsole.Test
{
    public class AutofacInjectorAdapterTest
    {
        [Test]
        public void Inject_MultiImplications_ThrowsException()
        {
            var stubTypeProvider = Substitute.For<ITypeProvider>();
            stubTypeProvider.GetTypes().Returns(new List<Type>()
            {
                Substitute.For<AutofacInjector>().GetType(),
                Substitute.For<AutofacInjector>().GetType()
            });

            var adapter = new AutofacInjectorAdapter();
            adapter._typeProvider = stubTypeProvider;

            Assert.Catch<MultiAutofacInjectorImplicationsException>(() =>
            {
                adapter.Inject();
            }, $"There are more than one implication of {nameof(AutofacInjector)}");
        }
    }
}