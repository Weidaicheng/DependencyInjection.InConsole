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
        public void getAutofacInjector_NoImplications_ReturnsFalse()
        {
            var stubTypeProvider = Substitute.For<ITypeProvider>();
            stubTypeProvider.GetTypes().Returns(new List<Type>()
            {
            });

            var adapter = new AutofacInjectorAdapter();
            adapter._typeProvider = stubTypeProvider;

            var result = adapter.getAutofacInjector(out AutofacInjector injector);
            Assert.False(result);
        }

        [Test]
        public void getAutofacInjector_MultiImplications_ThrowsException()
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
                adapter.getAutofacInjector(out AutofacInjector injector);
            }, $"There are more than one implication of {nameof(AutofacInjector)}");
        }

        [Test]
        public void getAutofacInjector_OneImplication_ReturnsTrue()
        {
            var stubTypeProvider = Substitute.For<ITypeProvider>();
            stubTypeProvider.GetTypes().Returns(new List<Type>()
            {
                Substitute.For<AutofacInjector>().GetType()
            });

            var adapter = new AutofacInjectorAdapter();
            adapter._typeProvider = stubTypeProvider;

            var result = adapter.getAutofacInjector(out AutofacInjector injector);
            Assert.True(result);
        }
    }
}