using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Telerik.Utils
{
    public class DriverUtils
    {

        private  IWebDriver driver;
        public DriverUtils()
        {
            SelectDriver(AppSettingsReaderUtils.GetKey("browserType"));
            SetLoadTimeouts();
        }


        private void SelectDriver(string browser)
        {
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentException("Invalid browser");
            }
        }

        private void SetLoadTimeouts()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan
                .FromSeconds(AppSettingsReaderUtils.GetKeyInt("defaultPageLoadTime"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan
                .FromSeconds(AppSettingsReaderUtils.GetKeyInt("defaultImplicitWait"));
        }

        public  IWebDriver GetDriver()
        {
            return driver;
        }
        public  void NavigateToUrl(string url)
        {
            GetDriver().Navigate().GoToUrl(url);
        }
        public  void ResizeToFullScreen()
        {
            GetDriver().Manage().Window.Maximize();
        }

        public void QuitDriver()
        {
            GetDriver().Quit();
        }
    }
}
