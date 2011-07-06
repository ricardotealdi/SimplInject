using Ninject.Syntax;

namespace SimplInject.Scope
{
    public class NinjectBindingSingletonScope : INinjectBinding
    {
        public void Bind(IBindingWhenInNamedWithOrOnSyntax<object> ninjectBinding)
        {
            ninjectBinding.InSingletonScope();
        }
    }
}