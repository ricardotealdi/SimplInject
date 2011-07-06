using Ninject.Syntax;

namespace SimplInject.Scope
{
    public class NinjectBindingTransientScope : INinjectBinding
    {
        public void Bind(IBindingWhenInNamedWithOrOnSyntax<object> ninjectBinding)
        {
            ninjectBinding.InTransientScope();
        }
    }
}