using System;

namespace Aarthificial.Typewriter.Editor.Descriptors
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomEntryDescriptorAttribute : Attribute
    {
        public Type Type { get; }

        public CustomEntryDescriptorAttribute(Type type) => Type = type;
    }
}
