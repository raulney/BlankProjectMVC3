using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Blank.Infrastructure.Enums
{
    public class EnumHelper<T> where T : struct
    {
        public static IEnumerable<EnumHelper<T>> All()
        {
            foreach (T valor in Enum.GetValues(typeof(T)))
            {
                yield return new EnumHelper<T>(valor);
            }
        }

        public T Value { get; private set; }

        public EnumHelper(T value)
        {
            this.Value = value;
        }

        public string Label
        {
            get
            {
                FieldInfo infoField = Value.GetType().GetField(Value.ToString());
                Description[] attributes = (Description[])infoField.GetCustomAttributes(typeof(Description), false);

                Description firstValidAttribute = attributes.FirstOrDefault(a => !String.IsNullOrEmpty(a.Value));

                if (firstValidAttribute == null)
                {
                    return Value.ToString();
                }

                return firstValidAttribute.Value;
            }
        }
    }
}
