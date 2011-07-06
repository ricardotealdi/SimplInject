using Ninject.Syntax;

namespace SimplInject.Scope
{
    public class NinjectBindingThreadScope : INinjectBinding
    {
        public void Bind(IBindingWhenInNamedWithOrOnSyntax<object> ninjectBinding)
        {
            ninjectBinding.InThreadScope();
        }
    }
}