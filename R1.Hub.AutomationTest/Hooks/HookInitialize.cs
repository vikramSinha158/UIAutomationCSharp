using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using R1.Automation.UI.core.Commons;
using R1.Automation.UI.core.Reporting;
using R1.Automation.UI.core.Selenium.Base;
using R1.Hub.AutomationBase.Base;
using R1.Hub.AutomationBase.Config;
using R1.Hub.AutomationTest.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace R1.Hub.AutomationTest.Hooks
{

    [Binding]
    public class HookInitialize: TestInitializeHook
    {    
        private readonly ScenarioContext _scenariocontext;

        public HookInitialize(ScenarioContext scenarioContext)
        {
            _scenariocontext = scenarioContext;
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

        [AfterScenario]
        public void AfterScenario()
        {
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
