using Ninject.Syntax;

namespace SimplInject
{
    public static class ScopeFactory
    {
        public static void With(IBindingWhenInNamedWithOrOnSyntax<object> binding, SimplInjectScope scope)
        {
            switch (scope)
            {
                case SimplInjectScope.Transient:
                    binding.InTransientScope();
                    break;
                case SimplInjectScope.Request:
                    binding.InRequestScope();
                    break;
                case SimplInjectScope.Singleton:
                    binding.InSingletonScope();
                    break;
                case SimplInjectScope.Thread:
                    binding.InThreadScope();
                    break;
            }
        }
    }
}