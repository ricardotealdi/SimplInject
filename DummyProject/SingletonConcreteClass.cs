using SimplInject;

namespace DummyProject
{
    [SimplInject(SimplInjectScope.Singleton)]
    public class SingletonConcreteClass : IAmAnotherInterface
    {
    }
}