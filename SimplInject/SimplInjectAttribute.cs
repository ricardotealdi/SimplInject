using System;

namespace SimplInject
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SimplInjectAttribute : Attribute
    {
        public SimplInjectAttribute()
        {
            Scope = SimplInjectScope.Transient;
        }

        public SimplInjectAttribute(SimplInjectScope scope)
        {
            Scope = scope;
        }

        public SimplInjectScope Scope { get; private set; }
    }

    public enum SimplInjectScope
    {
        Transient,
        Singleton,
        Thread,
        Request
    }
}