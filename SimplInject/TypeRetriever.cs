using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplInject
{
    public class TypeRetriever : ITypeRetriever
    {
        private readonly IAssemblyLoader _assemblyLoader;
        private readonly IAttributeVerifier _attributeVerifier;

        public TypeRetriever(IAssemblyLoader assemblyLoader, IAttributeVerifier attributeVerifier)
        {
            _assemblyLoader = assemblyLoader;
            _attributeVerifier = attributeVerifier;
        }

        public IEnumerable<Type> RetrieveFrom(string assemblyname)
        {
            return _assemblyLoader
                .RetrieveTypesFrom(assemblyname)
                .Where(
                    type => 
                        _attributeVerifier.HasAttribute(type)).ToList();
        }
    }
}
