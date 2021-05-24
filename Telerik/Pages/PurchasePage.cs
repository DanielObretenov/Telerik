using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using Telerik.Common.Data;
using Telerik.Common.Data.ProductData;
using Telerik.Common.Enums;
using Telerik.Common.Utils;
using Telerik.Utils;

namespace Telerik.Pages
{
    public class PurchasePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".Pricings-button [class^='UI'] div a")]
        protected IWebElement devCraftUIButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".Pricings-button [class^='Complete'] div a")]
        protected IWebElement devCraftCompleteButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".Pricings-button [class^='Ultimate'] div a")]
        protected IWebElement devCraftUltimateButton { get; set; }

    

        
        public PurchasePage(IWebDriver driver): base(driver)
        {
        }

        public void AddProductsToCart(ProductList products)
        {
            AcceptCookies();
            for (int i = 0; i < products.getSize(); i++)
            {
                AddProductToCart(products.getProductByIndex(i));
                if (i==0)
                {
                    WaitUtil.WaitForLoaderToDisapear(driver);
                    WaitUtil.ClickableElement(driver, acceptCookies);
                    AcceptCookies();
                }
                if (i < products.getSize() - 1)
                {
                    GoBackToPurchasePage();
                }
            }
        }

        private void AddProductToCart(Product product)
        {

            switch (product.ProductType)
            {
                case ProductTypesEnum.Complete:
                    common.ClickOnElement(devCraftCompleteButton);
                    break;
                case ProductTypesEnum.UI:
                    common.ClickOnElement(devCraftUIButton);
                    break;
                case ProductTypesEnum.Ultimate:
                    common.ClickOnElement(devCraftUltimateButton);
                    break;
            }
        }

        private void GoBackToPurchasePage()
        {
            common.MoveToElementAndClick(driver, continueShoppingButton);
        }

    }
}
