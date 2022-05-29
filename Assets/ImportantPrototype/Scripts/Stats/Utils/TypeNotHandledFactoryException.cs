using System;

namespace ImportantPrototype.Stats
{
    public class TypeNotHandledFactoryException : Exception
    {
        public TypeNotHandledFactoryException(string typeName)
            : base($"Type ({typeName}) not handled by factory")
        { }
    }
}