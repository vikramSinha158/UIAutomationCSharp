using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R1.Hub.AutomationTest.TestData
{

    [JsonObject("TestData")]
    public  class DataSettings
    {
        [JsonProperty("MedicareCoverageType")]
        public string MedicareCoverageType { get; set; }

        [JsonProperty("SearchSevice")]
        public string SearchSevice { get; set; }

        [JsonProperty("AETNACoverageType")]
        public string AETNACoverageType { get; set; }

    }
}
