﻿using R1.Automation.UI.core.Selenium.Base;
using R1.Hub.AutomationBase.Base;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System.Collections.Generic;
using System.Text;
using R1.Automation.UI.core.Reporting;
using R1.Automation.UI.core.Commons;
using TechTalk.SpecFlow;
using R1.Automation.UI.core.Selenium.Extensions;

namespace R1.Hub.AutomationBase.Config
{
    public class TestInitializeHook
    {
        ExtentReport ER = new ExtentReport();

        [ThreadStatic]
        private static ExtentTest featureName;
        [ThreadStatic]
        private static ExtentTest scenario;
        private static AventStack.ExtentReports.ExtentReports extent;
        private static string path;

        /// <summary>
        /// Initialzing data,report and driver
        /// </summary>
        public static void InitializeSettings()
        {
            ConfigReader.SetConfigSetting();
            DriverContext.driver = DriverFactory.InitDriver(Settings.BrowserName);

            if (Settings.ExtentReportReq)
            {
                extent = ExtentReport.InitReport(Settings.ReportPath);
                path = CommonUtility.DeleteOldFolders(Settings.ScreenShotsPath, Settings.LastScreenShotDays);
                path = CommonUtility.CreateFolder(path);
            }
        }

        /// <summary>
        /// Get feature info
        /// </summary>
        /// <param name="featureContext"></param>
        public static void GetFeatureInfo(FeatureContext featureContext)
        {
            if (Settings.ExtentReportReq)
            {
                //Create dynamic feature name
                featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            }
        }


        /// <summary>
        /// getscednario info
        /// </summary>
        /// <param name="scenarioContext"></param>
        public void GetScenarioInfo(ScenarioContext scenarioContext)
        {
            if (Settings.ExtentReportReq)
            {
                scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            }
        }

        public void GetStepInfo(ScenarioContext scenarioContext)
        {
            if (Settings.ExtentReportReq)
            {
                object TestResult = ER.ConfigSteps(scenarioContext);
                bool pass = Settings.PassScreenShotReq;
                bool fail = Settings.FailScreenShotReq;
                ER.InsertStepsInReport(scenarioContext, TestResult, path, scenario, pass, fail);
            }

        }


        /// <summary>
        /// publish report
        /// </summary>
        public static void PublishReport()
        {
            if (Settings.ExtentReportReq)
            {
                //Flush report once test completes
                extent.Flush();
            }
        }

        /// <summary>
        /// Naviate url
        /// </summary>
        public virtual void NaviateSite()
        {
            DriverContext.driver.Navigate().GoToUrl(Settings.AUT);
            DriverContext.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.ImplicitWait);
        }


        /// <summary>
        /// Close browser
        /// </summary>
        /// <param name="browsercloseflag"></param>
        public void CloseBrowser(bool browsercloseflag)
        {
            if (browsercloseflag)
            {
                DriverFactory.CloseAllDrivers();
            }
        }




    }
}
