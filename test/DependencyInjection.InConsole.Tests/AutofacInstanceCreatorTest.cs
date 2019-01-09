using System;
using System.Collections.Generic;
using DependencyInjection.InConsole.Exceptions;
using DependencyInjection.InConsole.Injec.Autofac;
using DependencyInjection.InConsole.Types;
using NSubstitute;
using NUnit.Framework;

namespace DependencyInjection.InConsole.Test
{
    public class AutofacInstanceCreatorTest
    {
        [Test]
        public void getAutofacInjector_NoImplications_ReturnsFalse()
        {
            var stubTypeProvider = Substitute.For<ITypeProvider>();
            stubTypeProvider.GetTypes().Returns(new List<Type>()
            {
            });
            var typeFactory = new TypeFactory();
            typeFactory._typeProvider = stubTypeProvider;

            var creator = new AutofacInstanceCreator<AutofacInjector>();

            var result = creator.GetInjectorImpTypes(typeFactory, out AutofacInjector injector);
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
            var typeFactory = new TypeFactory();
            typeFactory._typeProvider = stubTypeProvider;

            var creator = new AutofacInstanceCreator<AutofacInjector>();

            Assert.Catch<MultiAutofacInjectorImplicationsException>(() =>
            {
                creator.GetInjectorImpTypes(typeFactory, out AutofacInjector injector);
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
            var typeFactory = new TypeFactory();
            typeFactory._typeProvider = stubTypeProvider;

            var creator = new AutofacInstanceCreator<AutofacInjector>();

            var result = creator.GetInjectorImpTypes(typeFactory, out AutofacInjector injector);
            Assert.True(result);
        }
    }
}