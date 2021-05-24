using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Telerik.Utils
{
    public class ExtentReportUtils
    {
        private ExtentHtmlReporter extentHtmlReporter;

        private ExtentReports extentReports;

        private ExtentTest extentTest;

        private string DEFAULT_BROWSER = AppSettingsReaderUtils.GetKey("browserType");
        private string DEFAULT_TEST_CASE_NAME = "Initial setup";

        public ExtentReportUtils()
        {
            extentHtmlReporter = new ExtentHtmlReporter(PathUtils.GetCurrentReportPath());
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
            CreateTest(DEFAULT_TEST_CASE_NAME);
            AddLog(Status.Info, $"Browser type = {DEFAULT_BROWSER}");

        }
        public void AddScreenshot(string screenShotPath)
        {
            extentTest.AddScreenCaptureFromPath(screenShotPath);
        }
        public void CreateTest(string name)
        {
            extentTest = extentReports.CreateTest(name);
        }

        public void AddLog(Status status, string comment)
        {
            extentTest.Log(status, comment);
        }

        public void FlushReport()
        {
            extentReports.Flush();
        }
       

    }
}
