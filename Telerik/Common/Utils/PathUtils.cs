using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Telerik.Utils
{
    public class PathUtils
    {
        public static string GetCurrentPath()
        {
            var currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            return appPathMatcher.Match(currentPath).Value;
        }

        public static string GetScreenShotPathWithCurrentTimestamp()
        {
            string currentTimeStapm = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss");
            return $"{GetCurrentPath()}\\Resourses\\Screenshots\\currentTest-{currentTimeStapm}.jpeg";
        }
        public static string GetCurrentReportPath()
        {
            return GetCurrentPath() + "\\Resourses\\Reports\\TestReport.html";
        }
    }
}
