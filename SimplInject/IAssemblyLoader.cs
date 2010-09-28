using System;
using System.Collections.Generic;

namespace SimplInject
{
    public interface IAssemblyLoader
    {
        IEnumerable<Type> RetrieveTypesFrom(string assemblyName);
    }
}