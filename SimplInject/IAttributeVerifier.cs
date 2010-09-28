using System;

namespace SimplInject
{
    public interface IAttributeVerifier
    {
        bool HasAttribute(Type type);
    }
}