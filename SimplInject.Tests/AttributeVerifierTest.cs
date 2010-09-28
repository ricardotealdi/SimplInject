using DummyProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace SimplInject.Tests
{
    [TestClass]
    public class AttributeVerifierTest
    {
        private AttributeVerifier _verifier;

        [TestInitialize]
        public void SetUp()
        {
            _verifier = new AttributeVerifier();
        }

        [TestMethod]
        public void ShouldBeTrueIfTheTypeHasTheSimplInjectAttribute()
        {
            _verifier.HasAttribute(typeof (ConcreteClass)).Should().Be.True();
        }

        [TestMethod]
        public void ShouldBeFalseIfTheTypeHasTheSimplInjectAttribute()
        {
            _verifier.HasAttribute(typeof (IAmAnInterface)).Should().Be.False();
        }
    }
}
