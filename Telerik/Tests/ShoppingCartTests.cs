using NUnit.Framework;
using Telerik.Common.Attributes;
using Telerik.Common.Data;
using Telerik.Common.Data.ProductData;
using Telerik.Common.Enums;
using Telerik.Pages;
using Telerik.Utils;

namespace Telerik.Tests
{

    class ShoppingCartTests : BaseTest
    {

        PurchasePage purchasePage;
        ShoppingCartPage shoppingPage;

        //ready
      //  [Test]
        public void AddSameProductToCartTwice()
        {
            purchasePage = new PurchasePage(driverUtils.GetDriver());
            shoppingPage = new ShoppingCartPage(driverUtils.GetDriver());

            Product product1 = new Product(ProductTypesEnum.Complete);
            Product product2 = new Product(ProductTypesEnum.Complete);
            ProductList productList = new ProductList(product1, product2);
            purchasePage.AddProductsToCart(productList);
            Assert.Equals(productList.getSize(), shoppingPage.GetProductCount());
        }

        //ready
     //   [Test]
        public void CheckDiscountsByAddingProductAndChangingQuantity()
        {

            purchasePage = new PurchasePage(driverUtils.GetDriver());
            shoppingPage = new ShoppingCartPage(driverUtils.GetDriver());

            Product uiIProduct = new Product(ProductTypesEnum.UI, UnitDiscountsEnum.Nine, YearlyDiscountsEnum.Year3Plus);
            Product competeProduct = new Product(ProductTypesEnum.Complete, UnitDiscountsEnum.Four, YearlyDiscountsEnum.Year1Plus);
            ProductList productList = new ProductList(competeProduct, uiIProduct);
            shoppingPage.Products = productList;

            purchasePage.AddProductsToCart(productList);
            shoppingPage.FillInInitialProductInfo();
            shoppingPage.SetQuantitiesForProducts();

            foreach (var product in productList.GetProducts())
            {
                Assert.AreEqual(product.UnitDiscount.GetPriceAfterDiscount(), product.actualProduct.UnitLabelPrice);
                Assert.AreEqual(product.UnitDiscount.GetDiscountPerItem(), product.actualProduct.UnitSavedLabelPrice);
                Assert.AreEqual(product.YearlyDiscount.GetPriceAfterDiscountPerYear(), product.actualProduct.YearlyLabelPrice);
                Assert.AreEqual(product.YearlyDiscount.GetTotalSavedPricePerItem(), product.actualProduct.YearlySavedLabelPrice);
                Assert.AreEqual(product.TotalPriceAfterDiscounts(), product.actualProduct.ProductSubtotalLabelPrice);
            }

            Assert.AreEqual(productList.TotalLicenseBeforeDiscount(), shoppingPage.actualProducts.LicensesPricetWithoutDiscount);
            Assert.AreEqual(productList.TotalMaintenanseAndSupportBeforeDiscount(), shoppingPage.actualProducts.MaintenanceSupportPricetWithoutDiscount);
            Assert.AreEqual(productList.TotalDiscounts(), shoppingPage.actualProducts.TotalDiscounts);
            Assert.AreEqual(productList.TotalPriceAfterDiscounts(), shoppingPage.actualProducts.TotalPrice);
        }
        [Test]
        public void RemoveProductFromCart()
        {
            purchasePage = new PurchasePage(driverUtils.GetDriver());
            shoppingPage = new ShoppingCartPage(driverUtils.GetDriver());

            Product uiIProduct = new Product(ProductTypesEnum.UI, UnitDiscountsEnum.Nine, YearlyDiscountsEnum.Year3Plus);
            Product competeProduct = new Product(ProductTypesEnum.Ultimate, UnitDiscountsEnum.Four, YearlyDiscountsEnum.Year3Plus);
            ProductList productList = new ProductList(uiIProduct, competeProduct);
            purchasePage.AddProductsToCart(productList);
            shoppingPage.Products = productList;
            shoppingPage.RemoveProduct(uiIProduct);

            Assert.AreEqual(productList.getSize(), shoppingPage.GetProductCount());

        }

    }
}
