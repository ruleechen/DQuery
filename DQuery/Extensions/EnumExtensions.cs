using System;
using System.Collections.Generic;
using System.Linq;

namespace DQuery
{
    internal static class EnumExtensions
    {
        public static object GetAttachedValue(this Enum field, object key = null)
        {
            return field.GetAttachedValues(key).FirstOrDefault();
        }

        public static IEnumerable<object> GetAttachedValues(this Enum field, object key = null)
        {
            return field.GetAttachedKeyValues()
                .Where(x => key == null || object.Equals(key, x.Key))
                .Select(x => x.Value);
        }

        public static IEnumerable<KeyValuePair<object, object>> GetAttachedKeyValues(this Enum field)
        {
            var fieldInfo = field.GetType().GetFields().FirstOrDefault(x => x.Name == field.ToString());

            var attrs = fieldInfo.GetCustomAttributes(typeof(AttachAttribute), false).OfType<AttachAttribute>();

            return attrs.Select(x => new KeyValuePair<object, object>(x.Key, x.Value));
        }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    internal class AttachAttribute : Attribute
    {
        public AttachAttribute(object value)
            : this(null, value)
        {
        }

        public AttachAttribute(object key, object value)
        {
            Key = key;
            Value = value;
        }

        public object Key { get; private set; }

        public object Value { get; private set; }
    }
}
