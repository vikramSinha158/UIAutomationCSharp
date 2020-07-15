using Microsoft.Extensions.Configuration;
using R1.Automation.UI.core.Commons;
using R1.Hub.AutomationBase.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace R1.Hub.AutomationTest.TestData
{
    public class DataReader
    {
        public static void SetTestData() {

            Settings.TData = CommonUtility.TestData(Settings.TestDataFolder + "/" + Settings.TestDataFile);

            Settings.MedicareCoverageType = Settings.TData.GetSection("TestData").Get<DataSettings>().MedicareCoverageType;

            Settings.SerachServiceCode = Settings.TData.GetSection("TestData").Get<DataSettings>().SearchSevice;

            Settings.AETNACovergaeType = Settings.TData.GetSection("TestData").Get<DataSettings>().AETNACoverageType;

            Settings.ConversionFollowup = Settings.TData.GetSection("TestData").Get<DataSettings>().ConversionFollowup;


        }
    }
}
