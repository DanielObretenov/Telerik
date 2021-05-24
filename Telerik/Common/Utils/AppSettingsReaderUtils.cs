using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Telerik.Utils
{
    class AppSettingsReaderUtils
    {
        private static AppSettingsReaderUtils settings;
        private static IConfiguration configuration;
        private AppSettingsReaderUtils()
        {
            configuration = new ConfigurationBuilder()
              .AddJsonFile(PathUtils.GetCurrentPath() + "/config/appSettings.json", true, true)
              .Build();
        }

        private static void InitSettings()
        {
            if(settings == null)
            {
                settings = new AppSettingsReaderUtils();
            }
        }
        
        public static string GetKey(string value)
        {
            InitSettings();
            return configuration[value];
        }
        public static int GetKeyInt(string value)
        {
            InitSettings();
            return int.Parse(configuration[value]);
        }

    }
}
