using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Telerik.Pages
{
    public class OrderSummaryPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "h1")]
        protected IWebElement OrderSummaryTitle { get; set; }
        public OrderSummaryPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetSummaryPageTitle()
        {
            return OrderSummaryTitle.Text;
        }
    }
}
