using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Common.Attributes;

namespace Telerik.Data
{
    public class UnitDiscount
    {
        public string Name { get; set; }
        private double percentage;
        private double unitPrice;

        private double priceAfterDiscount;
        private double totalPriceAfterDiscount;

        private double discountPerItem;
        private double totalSavedPrice;
        private int unitCount;


        public UnitDiscount(double unitPrice, Enum discountEnum)
        {
            this.Name = discountEnum.GetAttribute<DiscountInfo>().Value; 
            this.percentage = discountEnum.GetAttribute<DiscountInfo>().ItemInfo;
            this.unitPrice = unitPrice;
            SetUnitCount();

        }
        public int GetUnitCount()
        {
            return unitCount;
        }
        private void SetUnitCount()
        {
            unitCount = int.Parse(Name);
        }
        public double GetPriceAfterDiscount()
        {
            return priceAfterDiscount;
        }
        
        private void SetPriceAfterDiscount()
        {
            priceAfterDiscount = Math.Round(unitPrice * (1 - percentage/100), 2);
        }
        public double GetTotalPriceAfterDiscount()
        {
            return totalPriceAfterDiscount;
        }
        private void SetTotalPriceAfterDiscount()
        {
            totalPriceAfterDiscount = priceAfterDiscount * unitCount;
        }
        public double GetTotalSavedPrice()
        {
            return totalSavedPrice;
        }
        private void SetTotalSavedItemPrice()
        {
            totalSavedPrice = discountPerItem * unitCount;
        }
       
        public double GetDiscountPerItem()
        {
            return discountPerItem;
        }

        private void SetDiscountPerItem()
        {
            discountPerItem = unitPrice * (percentage/100);
        }

        public void CalculateDiscounts()
        {
            SetPriceAfterDiscount();
            SetTotalPriceAfterDiscount();

            SetDiscountPerItem();
            SetTotalSavedItemPrice();
        }

        public double TotalUnitPriceWithoutDiscounts()
        {
            return unitPrice * unitCount;
        }
    }
}
