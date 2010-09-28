using Ninject;
using MACSkeptic.Commons.Extensions;

namespace SimplInject
{
    public class SimplInjectRepository
    {
        private static ITypeRetriever _typeRetriever;
        
        private static StandardKernel _kernel;

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
            RegisterDependencies();
            _typeRetriever
                .RetrieveFrom(assemblyname)
                .Each(
                    type =>
                        type.GetInterfaces().Each(@interface => _kernel.Bind(@interface).To(type)));
        }

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
