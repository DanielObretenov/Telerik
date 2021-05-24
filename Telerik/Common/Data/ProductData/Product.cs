using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Common.Attributes;
using Telerik.Common.Data.ProductData;
using Telerik.Common.Enums;
using Telerik.Data;

namespace Telerik.Common.Data
{
    public class Product 
    {
        public YearlyDiscount YearlyDiscount { get; set; }
        public UnitDiscount UnitDiscount { get; set; }
        public YearlyDiscountsEnum yearlyDiscountEnum;
        public UnitDiscountsEnum unitDiscountEnum;
        private string name;
        public double InitalUnitPrice { get; set; }
        public double UnitPrice { get; set; }
        public double SavedPricePerUnit { get; set; }
        public double YearlyPrice { get; set; }
        public double SavedPricePerYear { get; set; }
        public double SubTotalPricePerProduct { get; set; }
        public bool IsAutoRenewed { get; set; }
        public double AutoRenewedInitalPrice { get; set; }
        public ProductTypesEnum ProductType { get; set; }

        public ActualProduct actualProduct;

        public Product(ProductTypesEnum productType, UnitDiscountsEnum unit, YearlyDiscountsEnum yearly)
        {

            this.unitDiscountEnum = unit;
            this.yearlyDiscountEnum = yearly;
            ProductType = productType;
            actualProduct = new ActualProduct(productType);
            SetUnitDiscount();
            SetYearlyDiscount();
            SetName();
        }

        public Product(ProductTypesEnum productType)
        {

            ProductType = productType;
            actualProduct = new ActualProduct(productType);
            SetUnitDiscount();
            SetYearlyDiscount();
            SetName();
        }

        public void SetYearlyDiscount()
        {
            YearlyDiscount = new YearlyDiscount(yearlyDiscountEnum, AutoRenewedInitalPrice, UnitDiscount.GetUnitCount());
        }
        public void SetUnitDiscount()
        {
            UnitDiscount = new UnitDiscount(InitalUnitPrice, unitDiscountEnum);
        }
      
        private void SetName()
        {
            name = "DevCraft " + ProductType.ToString();
        }
        public string GetName()
        {
            return name;
        }

        public double GetTotalSavedMoneyFromDiscounts()
        {
            return UnitDiscount.GetTotalSavedPrice() + YearlyDiscount.GetTotalSavedPrice();
        }
        public double TotalPriceAfterDiscounts()
        {
            return UnitDiscount.GetTotalPriceAfterDiscount() + YearlyDiscount.GetTotalPriceAfterDiscount();
        }

    }
}
