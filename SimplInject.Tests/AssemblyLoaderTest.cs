using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace SimplInject.Tests
{
    [TestClass]
    public class AssemblyLoaderTest
    {
        [TestMethod]
        public void ShouldRetrieveAllTypesFromAGivenAssemblyName()
        {
            new AssemblyLoader().RetrieveTypesFrom("DummyProject").Should().Have.Count.EqualTo(3);
        }
    }
}
