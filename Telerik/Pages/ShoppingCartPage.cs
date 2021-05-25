using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using Telerik.Common.Data;
using Telerik.Common.Data.ProductData;
using Telerik.Common.Utils;
using static Telerik.Common.Utils.CommonCommands;

namespace Telerik.Pages
{
    public class ShoppingCartPage : BasePage
    {

        [FindsBy(How = How.CssSelector, Using = ".Pricings-button [class^='UI'] div a")]
        protected IWebElement loaderIconElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/span[contains(@class,'e2e-licenses-price')]")]
        protected IWebElement LicensesPricetWithoutDiscountElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/span[contains(@class,'e2e-maintenance-price')]")]
        protected IWebElement MaintenanceSupportPricetWithoutDiscountElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/span[contains(@class,'e2e-total-discounts-price')]")]
        protected IWebElement TotalDiscountsElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/span[contains(@class,'e2e-total-price')]")]
        protected IWebElement TotalPriceElement { get; set; }

        [FindsBy(How = How.XPath, Using = "td.product-name-cell")]
        protected IList<IWebElement> shoppingCartElements { get; set; }


        [FindsBy(How = How.CssSelector, Using = ".coupon-control-container .error-message")]
        protected IWebElement CounponErrorMessageElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".coupon-control-container input")]
        protected IWebElement CounponInputElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".coupon-control-container button")]
        protected IWebElement CounponButtonElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[contains(@class,'e2e-empty-shopping-cart-heading')]")]
        protected IWebElement EmptyShoppingCartMessageElement { get; set; }
     
        [FindsBy(How = How.CssSelector, Using = "button.e2e-continue")]
        protected IWebElement ContinueButtonElement { get; set; }

  

        private const string productNameLocator = "//div[normalize-space(text()) = '{0}']";
        private string yearlyPriceStringLocator = productNameLocator + "/ancestor::tr//td[@data-label = 'Maintenance & Support']//span[contains(@class, 'price-per-license-label')]";
        private string unitPriceStringLocator = productNameLocator + "//ancestor::tr//td[@data-label='Licenses']//span[contains(@class, 'e2e-price-per-license')]";
        private string initialAutoRenewalPriceStringLocator = productNameLocator + "/ancestor::tr//following-sibling::auto-renewal//label/span[not( contains(@class,'tooltip-holder'))]";
        private string savingYearlyLabelLocator = productNameLocator + "/ancestor::tr//td[@data-label = 'Maintenance & Support']//span[contains(@class,'savings-label')]";
        private string savingUnitLabelLocator = productNameLocator + "/ancestor::tr//td[@data-label='Licenses']//span[contains(@class, 'e2e-item-licenses-savings')]";
        private string kendoDropDownUnitPriceLocator = productNameLocator + "/ancestor::tr//quantity-select//span[contains(@class,'k-dropdown-wrap')]";
        private string kendoDropDownYearlyPriceLocator = productNameLocator + "/ancestor::tr//period-select//span[contains(@class,'k-dropdown-wrap')]";
        private string unitQuantityDiscountDropdownValueLocator = "//kendo-list//div[@class='k-list-scroller']/ul//li/div[normalize-space()='{0}']";
        private const string quantityDiscountDropdownValueLocator = "//kendo-list//div[@class='k-list-scroller']/ul//li//div/span[normalize-space()='{0}']";
        private string quantityDiscountDropdownDiscountPercentageLocator = quantityDiscountDropdownValueLocator + "/following-sibling::span";
        private string subtotalProductLocator = productNameLocator + "/ancestor::tr/td[contains(@class,'subtotal-cell')]/div";
        private string deleteButtonLocator = productNameLocator + "/ancestor::td[@class='product-name-cell']//div/a[contains(@class,'btn-delete-item')]";

        public ActualProducts actualProducts;


        protected IWebElement UnitPrice { get; set; }
        public ProductList Products { get; set; }
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
            actualProducts = new ActualProducts();
        }


        public void FillInInitialProductInfo()
        {
            foreach (var product in Products.GetProducts())
            {
                string initalAutoRenewPriceText = common.GetWebElementByXpath(driver, common.ConcatText(initialAutoRenewalPriceStringLocator, product.GetName())).Text;
                string initalUnitPriceText = GetElementTextForProduct(unitPriceStringLocator, product); 
                product.AutoRenewedInitalPrice = common.GetDoubleWithRegex(initalAutoRenewPriceText);
                product.InitalUnitPrice = common.GetDoubleWithRegex(initalUnitPriceText);
                product.SetUnitDiscount();
                product.SetYearlyDiscount();
            }
        }

      

        public void SetQuantitiesForProducts()
        {
        
            foreach (var product in Products.GetProducts())
            {
                common.MoveToElement(driver, continueShoppingButton);
                //unit
                IWebElement kendoUnitPriceDropdownElement = common.GetWebElementByXpath(driver, common.ConcatText(kendoDropDownUnitPriceLocator, product.GetName()));

                KendoUtil kendoUnitPriceDropdown = new KendoUtil(kendoUnitPriceDropdownElement);

                kendoUnitPriceDropdown.ClickOnKendoElement();

                IWebElement unitQuantityDiscountDropdownValueElement = common.GetWebElementByXpath(driver, common.ConcatText(unitQuantityDiscountDropdownValueLocator, product.UnitDiscount.Name));
                kendoUnitPriceDropdown.SelectItem(unitQuantityDiscountDropdownValueElement);

                //yearly
                IWebElement kendoYearlyPriceDropdownElement = common.GetWebElementByXpath(driver, common.ConcatText(kendoDropDownYearlyPriceLocator, product.GetName()));

                KendoUtil kendoYearlyPrice = new KendoUtil(kendoYearlyPriceDropdownElement);

                kendoYearlyPrice.ClickOnKendoElement();

                IWebElement yealyQuantityDiscountDropdownValueElement = common.GetWebElementByXpath(driver, common.ConcatText(quantityDiscountDropdownValueLocator, product.YearlyDiscount.Name));

                WaitUtil.VisibilityOfElement(driver, By.XPath(common.ConcatText(quantityDiscountDropdownDiscountPercentageLocator, product.YearlyDiscount.Name)));
               
                IWebElement yearlyDropdownDiscountPercentageElement = common.GetWebElementByXpath(driver, common.ConcatText(quantityDiscountDropdownDiscountPercentageLocator, product.YearlyDiscount.Name));

                string yearlyDiscountPercentage = yearlyDropdownDiscountPercentageElement.Text;

                kendoYearlyPrice.SelectItem(yealyQuantityDiscountDropdownValueElement);
              
                product.YearlyDiscount.SetPercentage(common.GetDoubleWithRegex(yearlyDiscountPercentage));

                //Calculate
                CalculateDiscounts(product);

                SetNewPricesForProducts(product);

                SetAllCommonPricesForProducts();
            }

        }

        public void SetNewPricesForProducts(Product product)
        {
            
            product.actualProduct.UnitLabelPrice = common.GetDoubleWithRegex(GetElementTextForProduct(unitPriceStringLocator, product));
            product.actualProduct.YearlyLabelPrice = common.GetDoubleWithRegex(GetElementTextForProduct(yearlyPriceStringLocator, product));
            product.actualProduct.ProductSubtotalLabelPrice = common.GetDoubleWithRegex(GetElementTextForProduct(subtotalProductLocator, product));
            product.actualProduct.UnitSavedLabelPrice = GetSavingPriceIfPresent(savingUnitLabelLocator, product); 
            product.actualProduct.YearlySavedLabelPrice = GetSavingPriceIfPresent(savingYearlyLabelLocator, product); 

        }
        public void SetAllCommonPricesForProducts()
        {
            actualProducts.LicensesPricetWithoutDiscount = common.GetDoubleWithRegex(LicensesPricetWithoutDiscountElement.Text);
            actualProducts.MaintenanceSupportPricetWithoutDiscount = common.GetDoubleWithRegex(MaintenanceSupportPricetWithoutDiscountElement.Text);
            actualProducts.TotalDiscounts = common.GetDoubleWithRegex(TotalDiscountsElement.Text);
            actualProducts.TotalPrice = common.GetDoubleWithRegex(TotalPriceElement.Text);
        }
        private string GetElementTextForProduct(string locator, Product product)
        {
            return common.GetWebElementByXpath(driver, common.ConcatText(locator, product.GetName())).Text;
        }
      


        private double GetSavingPriceIfPresent(string locator, Product product)
        {
            return common.IsElementPresent(driver, By.XPath(common.ConcatText(locator, product.GetName()))) 
                                    ? common.GetDoubleWithRegex(GetElementTextForProduct(locator, product)) 
                                    : 0;
        }
        private void CalculateDiscounts(Product product)
        {
            product.UnitDiscount.CalculateDiscounts();
            product.YearlyDiscount.CalculateDiscounts();
        }

        public int GetProductCount()
        {
            WaitUtil.WaitForLoaderToDisapear(driver);
            shoppingCartElements = driver.FindElements(By.CssSelector("td.product-name-cell"));
            return shoppingCartElements.Count;
        }

        public void RemoveProduct(Product product)
        {
            IWebElement element = common.GetWebElementByXpath(driver, common.ConcatText( deleteButtonLocator, product.GetName()));

            element.Click();
            Products.DeleteProductByName(product.ProductType);

        }

        public void AddCoupon(string coupon)
        {
            CounponInputElement.Clear();
            CounponInputElement.SendKeys(coupon);
        }

        public void ClickCouponButton()
        {
            CounponButtonElement.Click();
        }

        public string GetCouponErrorMessage()
        {
            return CounponErrorMessageElement.Text.Trim();
        }

        public string GetEmptyShoppingCartMessage()
        {
            return EmptyShoppingCartMessageElement.Text.Trim();
        }

        public void ClickOnContinueButton()
        {
            common.ClickOnElement(ContinueButtonElement);
        }
    }
}
