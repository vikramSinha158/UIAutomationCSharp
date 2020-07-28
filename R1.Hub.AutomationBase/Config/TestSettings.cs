using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R1.Hub.AutomationBase.Config
{

    [JsonObject("Connection")]
    public class TestSettings
    {

        [JsonProperty("AUT")]
        public string AUT { get; set; }

        [JsonProperty("Browser")]
        public string Browser { get; set; }

        [JsonProperty("ImplicitWait")]
        public string ImplicitWait { get; set; }
       
        [JsonProperty("ExtentReport")]
        public string ExtentReport { get; set; }
      
        [JsonProperty("ExtentReportFolderName")]
        public string ExtentReportFolderName { get; set; }

        
        [JsonProperty("ScreenShotsFolderName")]
        public string ScreenShotsFolderName { get; set; }

        [JsonProperty("NumberOfDaysToKeepScreenShots")]
        public string NumberOfDaysToKeepScreenShots { get; set; }

        [JsonProperty("ScreenShotsWithPassTestCases")]
        public string ScreenShotsWithPassTestCases { get; set; }

        [JsonProperty("ScreenShotsWithFailTestCases")]
        public string ScreenShotsWithFailTestCases { get; set; }

        [JsonProperty("AppUserName")]
        public string AppUserName { get; set; }

        [JsonProperty("AppPassword")]
        public string AppPassword { get; set; }

        [JsonProperty("TestDataFolderName")]
        public string TestDataFolderName { get; set; }

        [JsonProperty("TestDataFileName")]
        public string TestDataFileName { get; set; }
      
        [JsonProperty("BrowserFlag")]
        public string BrowserFlag { get; set; }

        [JsonProperty("AccretiveConnection")]
        public string AccretiveConnection { get; set; }

        [JsonProperty("TestQueryFileName")]
        public string TestQueryFileName { get; set; }

        [JsonProperty("Facility")]
        public string Facility { get; set; }

        [JsonProperty("NumberOfDaysToKeepExtentReport")]
        public string NumberOfDaysToKeepExtentReport { get; set; }
    }
}
