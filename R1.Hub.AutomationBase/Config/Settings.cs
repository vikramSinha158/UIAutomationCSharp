using Microsoft.Extensions.Configuration;
using R1.Automation.Database.core.Base;
using R1.Hub.AutomationBase.Common;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static string TestQueryFile { get; set; }

        public static string FacilatyCode { get; set; }

        public static bool BrowserFlag { get; set; }

        public static string MedicareCoverageType { get; set; }

        public static string SerachServiceCode { get; set; }

        public static string AETNACovergaeType { get; set; }

        public DataAccess DataAccess { get; set; } = new DataAccess();

       public Accretive TranDBcon { get; set; } = new Accretive();

        public static string AccretiveCon { get; set; }

        public static String ConversionFollowup { get; set; }

        public static String ISatRiskQuery { get; set; }

        public IDbConnection DbConnection { get; set; }

       
    }
}
