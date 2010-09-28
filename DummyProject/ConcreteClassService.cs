namespace DummyProject
{
    public class ConcreteClassService
    {
        public IAmAnotherInterface SingletonDependency { get; private set; }
        public IAmAnInterface TransientDependency { get; private set; }

        public ConcreteClassService(IAmAnInterface transientDependency, IAmAnotherInterface singletonDependency)
        {
            SingletonDependency = singletonDependency;
            TransientDependency = transientDependency;
        }
    }
}