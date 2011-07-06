using System.Collections.Generic;
using Ninject.Syntax;
using SimplInject.Scope;

namespace SimplInject
{
    public static class ScopeFactory
    {
        private static readonly NinjectBindingTransientScope NinjectBindingTransientScope = 
            new NinjectBindingTransientScope();
        private static readonly NinjectBindingRequestScope NinjectBindingRequestScope =
            new NinjectBindingRequestScope();
        private static readonly NinjectBindingSingletonScope NinjectBindingSingletonScope =
            new NinjectBindingSingletonScope();
        private static readonly NinjectBindingThreadScope NinjectBindingThreadScope =
            new NinjectBindingThreadScope();

        private static readonly
            IDictionary<SimplInjectScope, INinjectBinding> MapSimplinjectScopeToNinjectBindingScope =
                new Dictionary<SimplInjectScope, INinjectBinding>
                    {
                        {SimplInjectScope.Transient, NinjectBindingTransientScope},
                        {SimplInjectScope.Request, NinjectBindingRequestScope},
                        {SimplInjectScope.Singleton, NinjectBindingSingletonScope},
                        {SimplInjectScope.Thread, NinjectBindingThreadScope},
                    };

        public static void With(IBindingWhenInNamedWithOrOnSyntax<object> binding, SimplInjectScope scope)
        {
            MapSimplinjectScopeToNinjectBindingScope[scope].Bind(binding);
        }
    }
}