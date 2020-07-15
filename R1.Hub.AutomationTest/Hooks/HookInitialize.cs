using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using R1.Automation.Database.core.Base;
using R1.Automation.UI.core.Commons;
using R1.Automation.UI.core.Reporting;
using R1.Automation.UI.core.Selenium.Base;
using R1.Hub.AutomationBase.Base;
using R1.Hub.AutomationBase.Common;
using R1.Hub.AutomationBase.Config;
using R1.Hub.AutomationTest.TestData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TechTalk.SpecFlow;


namespace R1.Hub.AutomationTest.Hooks
{

    [Binding]
    public class HookInitialize: TestInitializeHook
    {    
        private readonly ScenarioContext _scenariocontext;
        private Settings _settings;

        public HookInitialize(ScenarioContext scenarioContext, Settings settings)
        {
            _scenariocontext = scenarioContext;
            _settings = settings;

        }

        [BeforeTestRun]
        public static void TestRun()
        {
            InitializeSettings();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            GetFeatureInfo(featureContext);
            DataReader.SetTestData();
        }

        [BeforeScenario]
        public void TestInitalize()
        {
            NaviateSite();
            GetScenarioInfo(_scenariocontext);

        }

        [BeforeScenario("DBConnection")]
        public void CreateDBConnection()
        {
            string tranStr = _settings.TranDBcon.GetTranConnectionString(Settings.FacilatyCode);
           _settings.DbConnection = _settings.DataAccess.ConnectToDB(tranStr);
        }

        [AfterScenario]
        public void AfterScenario()
        {
           _settings.DataAccess.CloseDBConnection();
            CloseBrowser(Settings.BrowserFlag);
            
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            GetStepInfo(_scenariocontext);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            PublishReport();
            DriverFactory.CloseAllDrivers();
        }
    }
}
