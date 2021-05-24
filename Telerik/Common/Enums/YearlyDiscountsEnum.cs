using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Common.Attributes;

namespace Telerik.Common.Enums
{
    public enum YearlyDiscountsEnum
    {
        [DiscountInfo("1 year", 0)]
        Year,
        [DiscountInfo("+1 year", 1)]
        Year1Plus,
        [DiscountInfo("+2 years", 2)]
        Year2Plus,
        [DiscountInfo("+3 years", 3)]
        Year3Plus,
        [DiscountInfo("+4 years", 4)]
        Year4Plus
    }
}
