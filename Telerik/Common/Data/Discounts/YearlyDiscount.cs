using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Common.Attributes;
using Telerik.Common.Enums;

namespace Telerik.Data
{
    public class YearlyDiscount 
    {
        public string Name { get; set; }
        public double percentage;
        private double unitPrice;
        private int unitCount;
        private double yearlyCount;

        private double priceAfterDiscount;
        private double totalPriceAfterDiscount;

        private double discountPerItem;
        private double totalSavedPrice;
        public YearlyDiscount(Enum discountEnum, double autoRenewedInitalPrice, int unitCount) 
        {
            this.Name =  discountEnum.GetAttribute<DiscountInfo>().Value;;
            this.unitCount = unitCount;
            this.unitPrice = autoRenewedInitalPrice;
            this.yearlyCount = discountEnum.GetAttribute<DiscountInfo>().ItemInfo;

        }

        public double GetPriceAfterDiscount()
        {
            return priceAfterDiscount;
        }

        private void SetPriceAfterDiscount()
        {
            priceAfterDiscount = unitPrice * (1 - percentage/100);
        }

        public double GetPriceAfterDiscountPerYear()
        {
           return priceAfterDiscount * unitCount;
        }
        public double GetTotalPriceAfterDiscount()
        {
            return totalPriceAfterDiscount ;
        }
        private void SetTotalPriceAfterDiscount()
        {
            totalPriceAfterDiscount = priceAfterDiscount * unitCount * yearlyCount;
        }
        public double GetTotalSavedPrice()
        {
            return totalSavedPrice;
        }
        public double GetTotalSavedPricePerItem()
        {
            return discountPerItem * unitCount;
        }
        private void SetTotalSavedItemPrice()
        {
            totalSavedPrice = discountPerItem * unitCount * yearlyCount;
        }

        public double GetDiscountPerItem()
        {
            return discountPerItem;
        }

        private void SetDiscountPerItem()
        {
            discountPerItem = unitPrice * percentage/100;
        }

        public void SetPercentage(double percentage)
        {
            this.percentage = percentage;
        }
        public double getPercentage()
        {
           return this.percentage;
        }

        public void CalculateDiscounts()
        {
            SetPriceAfterDiscount();
            SetDiscountPerItem();
            SetTotalPriceAfterDiscount();
            SetTotalSavedItemPrice();

        }

        public double GetYearlyPriceWithoutDiscounts()
        {
            return unitPrice * yearlyCount * unitCount;
        }
    }
}
