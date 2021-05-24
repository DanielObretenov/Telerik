using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Common.Enums;

namespace Telerik.Common.Data.ProductData
{
    public class ActualProduct
    {
        ProductTypesEnum productType;
        public double UnitLabelPrice { get; set; }
        public double UnitSavedLabelPrice { get; set; }
        public double YearlyLabelPrice { get; set; }
        public double YearlySavedLabelPrice { get; set; }
        public double ProductSubtotalLabelPrice { get; set; }
        
        public ActualProduct(ProductTypesEnum type)
        {
            productType = type;
        }
    }
}
