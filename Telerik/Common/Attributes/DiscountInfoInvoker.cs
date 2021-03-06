using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Common.Attributes
{
    public static class DiscountInfoInvoker
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
        where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }
    }
}
