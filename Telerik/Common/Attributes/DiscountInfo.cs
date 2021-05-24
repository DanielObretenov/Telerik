using System;
using System.Collections.Generic;
using System.Text;

namespace Telerik.Common.Attributes
{
    class DiscountInfo : Attribute
    {
        public string Value { get; private set; }
        public double ItemInfo { get; private set; }

        public DiscountInfo(string value, double itemInfo)
        {
            this.Value = value;
            this.ItemInfo = itemInfo;
        }

    }
}
