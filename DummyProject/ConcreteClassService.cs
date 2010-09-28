namespace DummyProject
{
    public class ConcreteClassService
    {
        private readonly IAmAnInterface _dependency;

        public ConcreteClassService(IAmAnInterface dependency)
        {
            _dependency = dependency;
        }
    }
}