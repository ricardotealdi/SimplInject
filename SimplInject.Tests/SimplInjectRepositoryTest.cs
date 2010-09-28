using DummyProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace SimplInject.Tests
{
    [TestClass]
    public class SimplInjectRepositoryTest
    {
        [TestMethod]
        public void ShouldInjectTypesFromAGivenAssemblyName()
        {          
            SimplInjectRepository.InjectTypesFrom("DummyProject");

            SimplInjectRepository.Get<ConcreteClassService>().Should().Not.Be.Null();
        }

        [TestMethod]
        public void ShouldInjectTypesBasedOnScope()
        {
            SimplInjectRepository.InjectTypesFrom("DummyProject");

            var service1 = SimplInjectRepository.Get<ConcreteClassService>();
            var service2 = SimplInjectRepository.Get<ConcreteClassService>();

            service1.SingletonDependency.Should().Be.EqualTo(service2.SingletonDependency);
            service1.TransientDependency.Should().Not.Be.EqualTo(service2.TransientDependency);
        }
    }
}
