using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using R1.Hub.AutomationBase.Config;
using Xunit;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using R1.Automation.UI.core.Selenium.Extensions;
using TechTalk.SpecFlow.Assist;
using System.Threading;

namespace R1.Hub.AutomationTest.Pages
{
    public class ConversionFollowupPage:BasePage
    {
        private int totalPageCnt;
        private int rowsPerPage = 15;
        private string firstXPathFilterFolder = "//div/span[text()='";
        private string lastXPathFilterFolder = "']";
        private string firstXpathfilterFolderName = "//span[contains(text(),'> ";
        private string lastXpathfilterFolderName = "')]";
        private string txtLatPage = "//span[contains(@id,'lblTotalPages')]";
        private string firstXaothCoverageCareFilterFolder = "//div/span[text()='Care Coverage']//preceding::div[1]/following-sibling::div/div[contains(@id,'WorklistPaneltreeProcessUltraWebTree')]//span[text()='";
        private string lastXpathCoveareCareFilterFolder = "']";
        private string xPathBSO = "//div/span[text()='BSO']";



        public ConversionFollowupPage(DriverContext driverContext) : base(driverContext)
        {
            PageFactory.InitElements(driverContext.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div/span[text()='Conversion Followup']")]
        private IWebElement conversionFollowup;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'dnnctr1478WorklistPaneltreeProcessUltraWebTree1_1')]//div//span[@igtxt='1']")]
        private IList<IWebElement> followupWorklist;

        [FindsBy(How = How.XPath, Using = "//table[@class='worklistTable']/tbody//tr[@valign='middle']")]
        private IList<IWebElement> worklistPanelTableRows;

        [FindsBy(How = How.XPath, Using = "//div/span[text()='I/S at Risk']")]
        private IWebElement ISatRisk;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblTotalPages')]")]
        private IWebElement lblTotalPages;
       
        [FindsBy(How = How.XPath, Using = "//a[@title='Last Record']")]
        private IWebElement lastPages;

        [FindsBy(How = How.XPath, Using = "//div/span[text()='Care Coverage']//preceding::span[2]//img[@imgtype='exp']")]
        private IWebElement expandCoverageCare;

        [FindsBy(How = How.XPath, Using = "//div/span[text()='Care Coverage']//preceding::div[1]/following-sibling::div/div[contains(@id,'WorklistPaneltreeProcessUltraWebTree')]//span[@igtxt='1']")]
        private IList<IWebElement> subFilterFolderCovCareList;

        public void VerifyConversionFollowDisplay()
        {
            util.IsDisplayed(conversionFollowup);
        }

        /// <summary>
        /// Verify Filter folder in Conversion followup
        /// </summary>
        public void verifyFilterFolder()
        {
            List<String> subfilterFolderList = new List<String>();
            //Thread.Sleep(3000);
            _driverContext.Driver.WaitForVisibility(3, By.XPath(xPathBSO));

            for (int i = 0; i < followupWorklist.Count; i++)
            {
                if(!(string.IsNullOrEmpty(followupWorklist[i].Text)))
                subfilterFolderList.Add(followupWorklist[i].Text);
            }
            List<String> expfollowupIList = util.GetTestData(Settings.ConversionFollowup);

            bool result = util.CompareList(subfilterFolderList, expfollowupIList);

            Assert.True(result,"Comversion followup subfilter folder not match with expected list,Actual filter folder count  " + subfilterFolderList.Count  + " Expected filter count " + expfollowupIList.Count);
        }


        /// <summary>
        /// Click on filter folder
        /// </summary>
        /// <param name="filterfolderName"></param>
        public void ClickOnFilterfolder(string filterfolderName)
        {

            _driverContext.Driver.FindElement(By.XPath(firstXPathFilterFolder + filterfolderName.Trim() + lastXPathFilterFolder)).Click();
        }

        /// <summary>
        /// Click on Coverage Care filter folder
        /// </summary>
        /// <param name="subFilterFolder"></param>
        public void ClickOnCoveraegCareFilterFolder(string subFilterFolder)
        {
            _driverContext.Driver.FindElement(By.XPath(firstXaothCoverageCareFilterFolder+ subFilterFolder.Trim()+ lastXpathCoveareCareFilterFolder)).Click();
        }


        /// <summary>
        /// Verify t=the name of filder folder
        /// </summary>
        /// <param name="filterfolderName"></param>
        public void verifyFilterfolderName(string filterfolderName)
        {
            bool filterfolderDisplayStatus = false;
            try
            {
                IWebElement filterName = _driverContext.Driver.FindElement(By.XPath(firstXpathfilterFolderName + filterfolderName.Trim() + lastXpathfilterFolderName));
                if (filterName.Displayed)
                    filterfolderDisplayStatus = true;
                util.ScrollHorizontal(_driverContext.Driver);
            }
            catch (NoSuchElementException e)
            {
                Assert.True(filterfolderDisplayStatus,"Filter folder is not Visble : " + filterfolderName);
            }
           
                         
        }


        /// <summary>
        /// Get total count of table from Ui for filter folder table
        /// </summary>
        /// <returns></returns>
        public int GetTotalWorkListRows()
        {
            _driverContext.Driver.WaitForVisibility(5, By.XPath(txtLatPage));
            totalPageCnt = int.Parse(lblTotalPages.Text);
            if (totalPageCnt > 1)
            {
                lastPages.Click();
                int lastpageRecord = worklistPanelTableRows.Count;
                int totalWorkListRows = (totalPageCnt - 1) * rowsPerPage + lastpageRecord;
                return totalWorkListRows;
            }
            else if (totalPageCnt==1)
            {
                return worklistPanelTableRows.Count;
            }
            else if (totalPageCnt == 0)
            {
                return totalPageCnt;
            }

            return 0;

        }

        /// <summary>
        /// Click to expand Coverage care sub filter folder
        /// </summary>
        public void ClickOnExpandCoveragecare()
        {
            expandCoverageCare.Click();
        }


        /// <summary>
        /// Veryfy SubFilter Folder Coverage Care
        /// </summary>
        /// <param name="table"></param>
        public void VeryfySubFilterFolderCoverageCare(Table table)
        {
            var subFilterfolderCoverageCare = table.CreateDynamicSet();

            List<String> subfilterFolderCoverageList = new List<String>();

            foreach (var subfilterfolder in subFilterfolderCoverageCare)
            {
                subfilterFolderCoverageList.Add(subfilterfolder.SubFilterFolderDeck);
                subfilterFolderCoverageList.Add(subfilterfolder.SubFilterFolderPending);
            }

            List<String> actCoverageList = util.GetElementList(subFilterFolderCovCareList);

            bool result = util.CompareList(subfilterFolderCoverageList, actCoverageList);

            Assert.True(result, "Comversion followup subfilter folder not match with expected list ");

        }

   



    }
}
