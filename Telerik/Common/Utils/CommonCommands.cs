using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Telerik.Utils;

namespace Telerik.Common.Utils
{
    public class CommonCommands
    {

        public  void ClickOnElement(IWebElement element)
        {
            element.Click();
        }

      
        public  void MoveToElement(IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
        public  void MoveToElementAndClick(IWebDriver driver, IWebElement element)
        {
            MoveToElement(driver, element);
            ClickOnElement(element);
        }

        public  bool IsElementPresent(IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
                
            }
        }

        public  double GetDoubleWithRegex(string text)
        {
            text = Regex.Replace(text, "[^0-9.]+", "");
            return text == "" ? 0 : double.Parse(text);
        }

        public  IWebElement GetWebElementByXpath(IWebDriver driver, string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }

        public string ConcatText(string text, string param)
        {
           return string.Format(text, param);
        }

        public void ClearAndSendKeys(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
