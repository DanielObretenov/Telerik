using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Telerik.Common.Utils;
using Telerik.Utils;

namespace Telerik.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected CommonCommands common;
        [FindsBy(How = How.CssSelector, Using = "#onetrust-accept-btn-handler")]
        protected IWebElement acceptCookies { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn.continue-shopping span")]
        protected IWebElement continueShoppingButton { get; set; }
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            common = new CommonCommands();
            PageFactory.InitElements(driver, this);
        }

        public void AcceptCookies()
        {
            common.ClickOnElement(acceptCookies);
        }
    }
}
