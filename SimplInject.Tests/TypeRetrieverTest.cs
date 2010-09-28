using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharpTestsEx;

namespace SimplInject.Tests
{
    [TestClass]
    public class TypeRetrieverTest
    {
        [TestMethod]
        public void ShouldRetrieveAllTypesWithSimplInjectAttribute()
        {
            const string assemblyname = "assemblyName";

            var assemblyLoaderMock = new Mock<IAssemblyLoader>();
            assemblyLoaderMock
                .Setup(it => it.RetrieveTypesFrom(assemblyname))
                .Returns(new List<Type> { typeof(DateTime), typeof(string) });

            var attributeVerifierMock = new Mock<IAttributeVerifier>();
            attributeVerifierMock.Setup(it => it.HasAttribute(It.IsAny<Type>())).Returns(false);
            attributeVerifierMock.Setup(it => it.HasAttribute(typeof (string))).Returns(true);

            var retriever = new TypeRetriever(assemblyLoaderMock.Object, attributeVerifierMock.Object);

            var typesToBeInjected = retriever.RetrieveFrom(assemblyname);
            typesToBeInjected.Should().Have.Count.EqualTo(1);
            typesToBeInjected.Should().Have.SameSequenceAs(typeof (string));
            typesToBeInjected.Should().Not.Have.SameSequenceAs(typeof (DateTime));

            assemblyLoaderMock.Verify(it => it.RetrieveTypesFrom(assemblyname), Times.Once());
            attributeVerifierMock.Verify(it => it.HasAttribute(It.IsAny<Type>()), Times.Exactly(2));
        }
    }
}