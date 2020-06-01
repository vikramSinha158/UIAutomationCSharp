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
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace R1.Hub.AutomationTest.Hooks
{

    [Binding]
    public class HookInitialize:ConfigReader
    {
        ExtentReport ER = new ExtentReport();
        
        [ThreadStatic]
        private static ExtentTest featureName;
        [ThreadStatic]
        private static ExtentTest scenario;
        private static AventStack.ExtentReports.ExtentReports extent;
        private readonly ScenarioContext _scenariocontext;
        private static string path;
        



        public HookInitialize(ScenarioContext scenarioContext)
        {
            _scenariocontext = scenarioContext;
        }

        [BeforeTestRun]
        public static void TestRun()
        {

            SetConfigSetting();
            DriverContext.driver = DriverFactory.InitDriver(Settings.BrowserName);

            if (Settings.ExtentReportReq)
            {
                extent = ExtentReport.InitReport(Settings.ReportPath);
                path = CommonUtility.DeleteOldFolders(Settings.ScreenShotsPath, Settings.LastScreenShotDays);
                path = CommonUtility.CreateFolder(path);
            }


        }

        [BeforeScenario]
        public void TestInitalize()
        {          
            DriverContext.driver.Navigate().GoToUrl(Settings.AUT);
            DriverContext.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.ImplicitWait);

            if (Settings.ExtentReportReq)
            {
                scenario = featureName.CreateNode<Scenario>(_scenariocontext.ScenarioInfo.Title);
            }
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            if (Settings.ExtentReportReq)
            {
                //object TestResult = ER.ConfigSteps(_scenariocontext);
                //bool pass = bool.Parse(TData["ScreenShotsWithPassTestCases"]);
                //bool fail = bool.Parse(TData["ScreenShotsWithPassTestCases"]);
                //ER.InsertStepsInReport(_scenariocontext, TestResult, path, scenario, pass, fail);
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //if (ExtentReportReq)
            //{
            //    //Flush report once test completes
            //    extent.Flush();
            //}
            DriverFactory.CloseAllDrivers();
        }
    }
}
