using Microsoft.Extensions.Configuration;
using R1.Automation.UI.core.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace R1.Hub.AutomationBase.Config
{
    public class ConfigReader
    {
        public static void SetConfigSetting() { 

            Settings.configurationRoot= CommonUtility.AppConfig;

            Settings.AUT = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().AUT;

            Settings.BrowserName = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().Browser;

            Settings.ImplicitWait = int.Parse(Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().ImplicitWait);

            Settings.ExtentReportReq= bool.Parse(Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().ExtentReport);

            Settings.ReportPath= Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().ExtentReportFolderName;

            Settings.ScreenShotsPath = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().ScreenShotsFolderName;

            Settings.LastScreenShotDays = Settings.configurationRoot.GetSection("Connection").Get<TestSettings>().NumberOfDaysToKeepScreenShots;
        }
    }
}
