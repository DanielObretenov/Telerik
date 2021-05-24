using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Telerik.Common.Utils
{
    class KendoUtil
    {
        private IWebDriver driver;
        private IWebElement parentEl;
        private CommonCommands common;
        public KendoUtil(IWebElement parentEl)
        {
            this.parentEl = parentEl;
            this.driver = ((IWrapsDriver)parentEl).WrappedDriver;
            common = new CommonCommands();
        }
        public void SelectItem(IWebElement element)
        {
            WaitUtil.WaitForLoaderToDisapear(driver);
            common.MoveToElementAndClick(driver, element);
            WaitUtil.WaitForLoaderToDisapear(driver);

        }
        public void ClickOnKendoElement()
        {
            common.ClickOnElement(parentEl);
        }
      

    }
}
