using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Common.Enums;

namespace Telerik.Common.Data.ProductData
{
    public class ProductList
    {
        private List<Product> products;
        public ProductList(params Product[] products)
        {
            this.products = new List<Product>();
            setProducts(products);
        }

        public void setProducts(Product[] products)
        {
            foreach (var product in products)
            {
                this.products.Add(product);
            }
        }


        public List<Product> GetProducts()
        {
            return products;
        }
        public int getSize()
        {
            return products.Count;
        }
        public Product getProductByIndex(int index)
        {
            if (index<getSize())
            {
                return products[index];
            }
            throw new ArgumentException("No such index");
        }

        public double TotalPriceAfterDiscounts()
        {
            double totalPrice = 0;
            foreach (var product in products)
            {
                totalPrice += product.TotalPriceAfterDiscounts();
            }
            return Math.Round(totalPrice, 2);
        }

        public double TotalLicenseBeforeDiscount()
        {
            double total = 0;
            foreach (var product in products)
            {
                total += product.UnitDiscount.TotalUnitPriceWithoutDiscounts();
            }
            return Math.Round(total, 2);
        }

        public double TotalMaintenanseAndSupportBeforeDiscount()
        {
            double total = 0;
            foreach (var product in products)
            {
                total += product.YearlyDiscount.GetYearlyPriceWithoutDiscounts();
            }
            return Math.Round(total, 2);
        }

        public double TotalDiscounts()
        {
            double total = 0;
            foreach (var product in products)
            {
                total += product.GetTotalSavedMoneyFromDiscounts();
            }
            return Math.Round(total, 2);
        }

        public void DeleteProductByName(ProductTypesEnum productName)
        {
       
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].ProductType == productName)
                {
                    products.RemoveAt(i);
                }
            }
        }
    }
}
