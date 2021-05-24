using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Text;

namespace Telerik.Utils
{
    public class GetScreenShot
    {
        public static void CaptureAndSave(IWebDriver driver, string screenShotPath)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            screenshot.SaveAsFile(screenShotPath);
        }


    }
}
