using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace R1.Hub.AutomationBase.Config
{
    public class Settings
    {
        public static IConfigurationRoot configurationRoot { get; set; }

        public static string AUT { get; set; }

        public static string BrowserName { get; set; }

        public static int ImplicitWait { get; set; }

        public static bool ExtentReportReq { get; set; }

        public static string ReportPath { get; set; }

        public static string ScreenShotsPath { get; set; }

        public static string LastScreenShotDays { get; set; }
    }
}
