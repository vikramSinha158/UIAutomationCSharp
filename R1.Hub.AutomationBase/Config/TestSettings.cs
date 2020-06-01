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


    }
}
