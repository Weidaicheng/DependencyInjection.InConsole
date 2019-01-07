using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjection.InConsole.Exceptions;
using DependencyInjection.InConsole.Injec;
using DependencyInjection.InConsole.Types;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;

namespace DependencyInjection.InConsole.Test
{
    public class InstanceCreatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetInjectorImpTypes_NoImplication_ThrowsException()
        {
            var stubTypeProvider = Substitute.For<ITypeProvider>();
            stubTypeProvider.GetTypes().Returns(new List<Type>()
            {
                typeof(InstanceCreatorTest)
            });

            var creator = new InstanceCreator<Injector>();
            
            Assert.Catch<NonImplicationException>(() =>
            {
                creator.GetInjectorImpTypes(stubTypeProvider);
            }, $"Can't find one implication of {typeof(Injector).Name}.");
        }

        [Test]
        public void GetInjectorImpTypes_Injector_1_ReturnsOneAndRightTypeInstance()
        {
            var stubTypeProvider = Substitute.For<ITypeProvider>();
            stubTypeProvider.GetTypes().Returns(new List<Type>()
            {
                typeof(Injector_1)
            });

            var creator = new InstanceCreator<Injector>();
            var result = creator.GetInjectorImpTypes(stubTypeProvider);

            Assert.NotZero(result.Count());
            Assert.IsTrue(result.Count() == 1);
            Assert.IsTrue(result.First().FullName == typeof(Injector_1).FullName);
        }

        [Test]
        public void GetInstance_Injector_1_ReturnsInjector_1()
        {
            var creator = new InstanceCreator<Injector>();
            var result = creator.GetInstance(typeof(Injector_1));

            Assert.IsTrue(result is Injector_1);
        }
    }

    public class Injector_1 : Injector
    {
        public override void Inject()
        {
            throw new NotImplementedException();
        }
    }
}