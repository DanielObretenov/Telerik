using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Telerik.Common.Utils;
using Telerik.Utils;

namespace Telerik.Tests
{
    class BaseTest
    {
        protected ExtentReportUtils extentReports;
        protected DriverUtils driverUtils;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extentReports = new ExtentReportUtils();
        }

        [SetUp]
        public void SetUp()
        {
            driverUtils = new DriverUtils();
            driverUtils.ResizeToFullScreen();
            driverUtils.NavigateToUrl(AppSettingsReaderUtils.GetKey("url"));
        }

        [TearDown]
        public void TearDown()
        {
          
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                string screenShotPath = PathUtils.GetScreenShotPathWithCurrentTimestamp();

                GetScreenShot.CaptureAndSave(driverUtils.GetDriver(), screenShotPath);
                extentReports.AddLog(Status.Fail, stackTrace + errorMessage);
                extentReports.AddScreenshot(screenShotPath);

            }

            driverUtils.QuitDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extentReports.FlushReport();
        }
    }
}
