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

        [Test]
        public void CheckDiscountsByAddingProductAndChangingQuantityWithOneProducts()
        {
            purchasePage = new PurchasePage(driverUtils.GetDriver());
            shoppingPage = new ShoppingCartPage(driverUtils.GetDriver());

            Product competeProduct = new Product(ProductTypesEnum.Complete, UnitDiscountsEnum.Seven, YearlyDiscountsEnum.Year4Plus);
            ProductList productList = new ProductList(competeProduct);
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
        public void CheckDiscountsByAddingProductAndChangingQuantityWithTwoProducts()
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
        public void AddSameProductToCartTwice()
        {
            purchasePage = new PurchasePage(driverUtils.GetDriver());
            shoppingPage = new ShoppingCartPage(driverUtils.GetDriver());

            Product product1 = new Product(ProductTypesEnum.Complete);
            Product product2 = new Product(ProductTypesEnum.Complete);
            ProductList productList = new ProductList(product1, product2);
            purchasePage.AddProductsToCart(productList);
            Assert.AreEqual(1, shoppingPage.GetProductCount());
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

       [Test]
        public void AddInvalidCoupon()
        {
            purchasePage = new PurchasePage(driverUtils.GetDriver());
            shoppingPage = new ShoppingCartPage(driverUtils.GetDriver());
            Product ultimateProduct = new Product(ProductTypesEnum.Ultimate);
            ProductList productList = new ProductList(ultimateProduct);
            driverUtils.NavigateToUrl(AppSettingsReaderUtils.GetKey("urlShoppingCart"));
            shoppingPage.AcceptCookies();
            shoppingPage.AddCoupon("Discount50");
            shoppingPage.ClickCouponButton();
            Assert.AreEqual("Coupon code is not valid.", shoppingPage.GetCouponErrorMessage());

        }
        [Test]
        public void EmptyShoppingCart()
        {
            purchasePage = new PurchasePage(driverUtils.GetDriver());
            shoppingPage = new ShoppingCartPage(driverUtils.GetDriver());

            Product uiIProduct = new Product(ProductTypesEnum.UI);
            ProductList productList = new ProductList(uiIProduct);
            purchasePage.AddProductsToCart(productList);
            shoppingPage.Products = productList;
            shoppingPage.RemoveProduct(uiIProduct);

            Assert.AreEqual("Your shopping cart is empty!" ,shoppingPage.GetEmptyShoppingCartMessage());
        }
    }
}
