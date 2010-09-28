using System;
using System.Linq;
using Ninject;
using MACSkeptic.Commons.Extensions;
using Ninject.Syntax;

namespace SimplInject
{
    public static class SimplInjectRepository
    {
        private static ITypeRetriever _typeRetriever;
        
        private static StandardKernel _kernel;

        static SimplInjectRepository()
        {
            RegisterDependencies();
        }

        private static void RegisterDependencies()
        {
            if (_kernel == null)
            {
                _kernel = new StandardKernel();
                _kernel.Bind<IAssemblyLoader>().To<AssemblyLoader>();
                _kernel.Bind<IAttributeVerifier>().To<AttributeVerifier>();
                _typeRetriever = _kernel.Get<TypeRetriever>();
            }
        }
        
        public static void InjectTypesFrom(string assemblyname)
        {
            _typeRetriever
                .RetrieveFrom(assemblyname)
                .Each(
                    RegisterTypeWithSimplInjectAttribute);
        }

        public static void RegisterTypeWithSimplInjectAttribute(Type type)
        {
            var attributes = type.GetCustomAttributes(typeof (SimplInjectAttribute), false);

            if(attributes.Any())
            {
                var simplInjectAttribute = (SimplInjectAttribute) attributes.FirstOrDefault();

                type.GetInterfaces()
                    .Each(@interface => ScopeFactory.With(RegisterType(@interface, type), simplInjectAttribute.Scope));
            }
            
        }

        public static IBindingWhenInNamedWithOrOnSyntax<object> RegisterType(Type @interface, Type type)
        {
            return _kernel.Bind(@interface).To(type);
        }
        
        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
