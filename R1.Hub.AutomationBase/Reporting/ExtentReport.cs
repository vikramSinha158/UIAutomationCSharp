using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System.Reflection;
using TechTalk.SpecFlow;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using R1.Hub.AutomationBase.Config;

namespace R1.Hub.AutomationBase.Reporting
{
    public class ExtentReport
    {
        /// <summary>Initializes the report.</summary>
        /// <param name="appFolderName">Name of the application folder.</param>
        /// <returns>Returns ExtentReport Object</returns>
        public static AventStack.ExtentReports.ExtentReports InitReport(string appFolderName)
        {          
            var folderName = GetDirName();
            string path;
            if (folderName != null || folderName != "")
            {
                path = Path.Combine(folderName.Substring(0, folderName.LastIndexOf("\\bin")), appFolderName + "\\");
                Settings.ReportDestinationPath = path;
                string folder = DateTime.Now.ToString("dd_MMM_yyyy");
                path = path + folder;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\";
                folder = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_tt");
                path = path + folder;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\";
                
                Settings.ReportSourcePath = path;
                ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
                htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
                AventStack.ExtentReports.ExtentReports extent = new AventStack.ExtentReports.ExtentReports();
                extent.AttachReporter(htmlReporter);
                return extent;
            }
            else
                return null;
        }

        /// <summary>Gets the name of the dir.</summary>
        /// <returns>Return current Directory path</returns>
        private static string GetDirName()
        {
            try
            {
                return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            catch (Exception ex)
            {
                if (ex is PathTooLongException || ex is System.ArgumentException)
                    return "";
                else
                    return null;
            }
        }

        /// <summary>This method is used to find size of a folder</summary>
        /// <param name="dInfo"></param>
        /// <param name="includeSubDir"></param>
        /// <returns>Size of a folder</returns>
        static long DirectorySize(DirectoryInfo dInfo, bool includeSubDir)
        {
            long totalSize = dInfo.EnumerateFiles()
                         .Sum(file => file.Length);
            if (includeSubDir)
            {
                totalSize += dInfo.EnumerateDirectories()
                         .Sum(dir => DirectorySize(dir, true));
            }
            return totalSize;
        }

        /// <summary>This method is used for delete archived folders</summary>
        /// <param name="appFolderName"></param>
        /// <param name="noOfDays"></param>
        public static void DeleteArchiveFolder(string appFolderName, string noOfDays)
        {
            int num = Int32.Parse(noOfDays);

            var folderName = GetDirName();
            string path = Path.Combine(folderName.Substring(0, folderName.LastIndexOf("\\bin")), appFolderName + "\\");

            string[] subFileEntries = Directory.GetFiles(path);
            foreach (string subFile in subFileEntries)
            {
                FileInfo d = new FileInfo(subFile);
                if (d.CreationTime < DateTime.Now.AddDays(-num))
                    d.Delete();
            }
        }

        /// <summary>Configurations the steps.</summary>
        /// <param name="scenarioContext">The scenario context.</param>
        /// <returns>Returns result as object</returns>
        public object ConfigSteps(ScenarioContext scenarioContext)
        {
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(scenarioContext, null);
            return TestResult;
        }

        /// <summary>Inserts the steps in report without screenshot support.</summary>
        /// <param name="scenarioContext">The scenario context.</param>
        /// <param name="TestResult">The test result.</param>
        /// <param name="scenario">The scenario under test</param>
        public void InsertStepsInReport(ScenarioContext scenarioContext,ExtentTest scenario, MediaEntityModelProvider mediaEntity)
        {
            object TestResult = ConfigSteps(scenarioContext);
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (scenarioContext.TestError == null && TestResult.ToString() != "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "When")
                    scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "And")
                    scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message, mediaEntity);
            }

            //Pending Status
            if (scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            }
        }
    }
}
