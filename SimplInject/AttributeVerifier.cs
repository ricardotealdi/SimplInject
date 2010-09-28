using System;

namespace SimplInject
{
    public class AttributeVerifier : IAttributeVerifier
    {
        public bool HasAttribute(Type type)
        {
            return Attribute.IsDefined(type, typeof (SimplInjectAttribute), false);
        }
    }
}