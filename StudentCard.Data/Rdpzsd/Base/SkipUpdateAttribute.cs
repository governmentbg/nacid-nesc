using System;
using System.Reflection;

namespace StudentCard.Data.Rdpzsd.Base
{
    public class SkipUpdateAttribute : Attribute
    {
        public static bool IsDeclared(PropertyInfo propertyInfo)
            => propertyInfo.GetCustomAttribute(typeof(SkipUpdateAttribute)) != null;
    }
}
