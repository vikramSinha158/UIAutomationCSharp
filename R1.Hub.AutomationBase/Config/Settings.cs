using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace R1.Hub.AutomationBase.Config
{
    public class Settings
    {
        public static IConfigurationRoot configurationRoot { get; set; }

        public static IConfigurationRoot TData { get; set; }

        public static string AUT { get; set; }

        public static string BrowserName { get; set; }

        public static int ImplicitWait { get; set; }

        public static bool ExtentReportReq { get; set; }

        public static string ReportPath { get; set; }

        public static string ScreenShotsPath { get; set; }

        public static string LastScreenShotDays { get; set; }

        public static bool PassScreenShotReq { get; set; }

        public static bool FailScreenShotReq { get; set; }

        public static string UserName { get; set; }

        public static string Password { get; set; }

        public static string TestDataFolder { get; set; }

        public static string TestDataFile { get; set; }

        public static string FacilatyCode { get; set; }

        public static bool BrowserFlag { get; set; }

        public static string SerachCoverageType { get; set; }
    }
}
