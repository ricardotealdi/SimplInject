using System;
using System.Collections.Generic;

namespace SimplInject
{
    public interface ITypeRetriever
    {
        IEnumerable<Type> RetrieveFrom(string assemblyname);
    }
}