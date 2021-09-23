using System;

namespace Task1
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TrackingPropertyAttribute : Attribute
    {
        public string PropertyName { get; }

        public TrackingPropertyAttribute(string name = null) => PropertyName = name;
    }
}
