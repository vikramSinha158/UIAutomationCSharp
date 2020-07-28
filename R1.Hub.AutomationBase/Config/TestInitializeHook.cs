using R1.Automation.UI.core.Selenium.Base;
using R1.Hub.AutomationBase.Base;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using R1.Automation.UI.core.Commons;
using TechTalk.SpecFlow;
using System.IO;
using R1.Hub.AutomationBase.Reporting;
using R1.Hub.AutomationBase.Common;

namespace R1.Hub.AutomationBase.Config
{
    public class TestInitializeHook
    {
        ExtentReport extentReport = new ExtentReport();


        [ThreadStatic]
        private static ExtentTest featureName;
        [ThreadStatic]
        private static ExtentTest scenario;
        private static AventStack.ExtentReports.ExtentReports extent;
        private DriverContext _driverContext;
        public DriverFactory driverFactory = new DriverFactory();
        private Utils util = new Utils();
        private CommonUtility commonUtility=new CommonUtility();
        private static string numberOfDaysToKeepExtent="0";

        public TestInitializeHook(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }
        /// <summary>
        /// Initialzing data,report and driver
        /// </summary>
        public void InitializeDriver()
        {
           
            _driverContext.Driver = driverFactory.InitDriver(Settings.BrowserName);
            _driverContext.Driver.Manage().Window.Maximize();

        }

        public static void InitializeSettings()
        {

            ConfigReader.SetConfigSetting();
            if (Settings.ExtentReportReq)
            {               
                extent = ExtentReport.InitReport(Settings.ReportPath);

                CommonUtility.DeleteOldFolders(Settings.ReportPath, Settings.KeepExtentReportDays);
                new Utils().DeleteFilesFromFolder(Settings.ReportPath, numberOfDaysToKeepExtent);
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
                
                var mediaEntity = util.CaptureScreenshotAndReturnModel(_driverContext.Driver,scenarioContext.ScenarioInfo.Title.Trim());
                extentReport.InsertStepsInReport(scenarioContext,scenario, mediaEntity);
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
                CopyReport();
            }
        }

        /// <summary>
        /// Naviate url
        /// </summary>
        public virtual void NaviateSite()
        {
            _driverContext.Driver.Navigate().GoToUrl(Settings.AUT);
            _driverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.ImplicitWait);
        }


        /// <summary>
        /// Close browser
        /// </summary>
        /// <param name="browsercloseflag"></param>
        public static  void CloseBrowser()
        {
            new DriverFactory().CloseAllDrivers();
        }

        private static void CopyReport()
        {         
               string[] sourcefiles = Directory.GetFiles(Settings.ReportSourcePath);

               foreach (string sourcefile in sourcefiles)
               {
                 string fileName = Path.GetFileName(sourcefile);
                 string destFile = Path.Combine(Settings.ReportDestinationPath, fileName);
                 File.Copy(sourcefile, destFile);
                }
           
        }


    }
}
