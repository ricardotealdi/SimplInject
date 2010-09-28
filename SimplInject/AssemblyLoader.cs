using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimplInject
{
    public class AssemblyLoader : IAssemblyLoader
    {
        public IEnumerable<Type> RetrieveTypesFrom(string assemblyName)
        {
            return Assembly.Load(assemblyName).GetTypes();
        }
    }
}
