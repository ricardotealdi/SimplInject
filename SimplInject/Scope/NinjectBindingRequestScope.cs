using Ninject.Syntax;

namespace SimplInject.Scope
{
    public class NinjectBindingRequestScope : INinjectBinding
    {
        public void Bind(IBindingWhenInNamedWithOrOnSyntax<object> ninjectBinding)
        {
            ninjectBinding.InRequestScope();
        }
    }
}