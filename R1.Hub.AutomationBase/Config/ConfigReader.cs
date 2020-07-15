using Microsoft.Extensions.Configuration;
using R1.Automation.UI.core.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace R1.Hub.AutomationBase.Config
{
    public class ConfigReader
    {
        /// <summary>
        /// Read the data from appsetting file
        /// </summary>
        public static void SetConfigSetting() { 

            Settings.configurationRoot= CommonUtility.AppConfig;

            Settings.AUT = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().AUT;

            Settings.BrowserName = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().Browser;

            Settings.ImplicitWait = int.Parse(Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().ImplicitWait);

            Settings.ExtentReportReq= bool.Parse(Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().ExtentReport);

            Settings.ReportPath= Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().ExtentReportFolderName;

            Settings.ScreenShotsPath = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().ScreenShotsFolderName;

            Settings.LastScreenShotDays = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().NumberOfDaysToKeepScreenShots;

            Settings.PassScreenShotReq = bool.Parse(Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().ScreenShotsWithPassTestCases);

            Settings.FailScreenShotReq = bool.Parse(Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().ScreenShotsWithFailTestCases);

            Settings.UserName = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().AppUserName;

            Settings.Password = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().AppPassword;

            Settings.TestDataFolder = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().TestDataFolderName;

            Settings.TestDataFile = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().TestDataFileName;

            Settings.BrowserFlag = bool.Parse(Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().BrowserFlag);

            Settings.AccretiveCon = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().AccretiveConnection;

            Settings.TestQueryFile = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().TestQueryFileName;

            Settings.FacilatyCode = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().Facility;
        }
    }
}
