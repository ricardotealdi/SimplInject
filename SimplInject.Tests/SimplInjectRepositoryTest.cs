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
    }
}
