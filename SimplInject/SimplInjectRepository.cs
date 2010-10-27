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
            if (_kernel != null)
                return;
            _kernel = new StandardKernel();
            _kernel.Bind<IAssemblyLoader>().To<AssemblyLoader>();
            _kernel.Bind<IAttributeVerifier>().To<AttributeVerifier>();
            _typeRetriever = _kernel.Get<TypeRetriever>();
        }
        
        public static void InjectTypesFrom(params string[] assemblyNames)
        {
            assemblyNames.Each(InjectTypesFrom);
        }

        public static IBindingWhenInNamedWithOrOnSyntax<object> RegisterType(Type @interface, Type type)
        {
            return _kernel.Bind(@interface).To(type);
        }

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public static object Get(Type type)
        {
            return _kernel.Get(type);
        }

        private static void InjectTypesFrom(string assemblyName)
        {
            _typeRetriever
                .RetrieveFrom(assemblyName)
                .Each(RegisterTypeWithSimplInjectAttribute);
        }

        private static void RegisterTypeWithSimplInjectAttribute(Type type)
        {
            var attributes = type.GetCustomAttributes(typeof (SimplInjectAttribute), false);

            if(attributes.Any())
            {
                var simplInjectAttribute = (SimplInjectAttribute) attributes.FirstOrDefault();

                type.GetInterfaces()
                    .Each(@interface => ScopeFactory.With(RegisterType(@interface, type), simplInjectAttribute.Scope));
            }
            
        }
    }
}
