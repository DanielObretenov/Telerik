using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Common.Attributes;

namespace Telerik.Common.Enums
{
    public enum UnitDiscountsEnum
    {
        [DiscountInfo("1", 0)]
        One,
        [DiscountInfo("2", 10)]
        Two,
        [DiscountInfo("3", 10)]
        Three,
        [DiscountInfo("4", 10)]
        Four,
        [DiscountInfo("5", 10)]
        Five,
        [DiscountInfo("6", 15)]
        Six,
        [DiscountInfo("7", 15)]
        Seven,
        [DiscountInfo("8", 15)]
        Eight,
        [DiscountInfo("9", 15)]
        Nine,
        [DiscountInfo("10", 15)]
        Ten,
        [DiscountInfo("11", 15)]
        ElevenPlus,
    }
}
