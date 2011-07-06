using Ninject.Syntax;

namespace SimplInject.Scope
{
    public interface INinjectBinding
    {
        void Bind(IBindingWhenInNamedWithOrOnSyntax<object> ninjectBinding);
    }
}