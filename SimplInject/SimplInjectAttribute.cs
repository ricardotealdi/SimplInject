using System;

namespace SimplInject
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SimplInjectAttribute : Attribute
    {
        public SimplInjectAttribute()
        {
            //Scope = NinjectableScope.Transient;
        }

        /*public SimplInjectAttribute(NinjectableScope scope)
        {
            Scope = scope;
        }*/

        //public NinjectableScope Scope { get; set; };
    }
}