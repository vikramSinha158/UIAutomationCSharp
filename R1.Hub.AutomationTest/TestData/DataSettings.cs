using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R1.Hub.AutomationTest.TestData
{

    [JsonObject("TestData")]
    public  class DataSettings
    {
        [JsonProperty("CoverageType")]
        public string CoverageType { get; set; }

    }
}
