using R1.Hub.AutomationBase.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using R1.Automation.UI.core.Selenium.Extensions;
using SeleniumExtras.PageObjects;
using R1.Hub.AutomationBase.Config;
using Xunit;

namespace R1.Hub.AutomationTest.Pages
{
    public class CoveragePage : BasePage
    {
        public CoveragePage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            PageFactory.InitElements(DriverContext.driver, this);
        }

        private string HeaderTypeCol = "Plan Name";
        private readonly int toprow = 1;
        private string delCoverageRows = "//table[contains(@id,'grdCoverageSelected')]//tr[@class='PanelDetail']//td//a//img[@title='Delete']";
        private string searchResult = String.Empty;
        private string searchRowLocator = "//table[contains(@id,'grdCoverageSearchResults')]//tr[@class='PanelDetail']";
        private string passCoveragetatus = "Passed";

        [FindsBy(How = How.XPath, Using = "//a[text()='Check Out']")]
        private IWebElement btnCheckOut;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtSearchPayors')]")]
        private IWebElement txtSearchCoverage;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'btnRunSearch')]")]
        private IWebElement btnFindCoverage;

        [FindsBy(How = How.XPath, Using = "//a[text()='Redo']")]
        private IWebElement btnRedo;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'grdCoverageSelected')]//tr[@class='PanelDetail']")]
        private IList<IWebElement> covergeTblRows;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'grdCoverageSearchResults')]//tr[@class='PanelTitle']//td")]
        private IList<IWebElement> serachResultCol;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'grdCoverageSearchResults')]//tr[@class='PanelDetail']")]
        private IList<IWebElement> serachResultRows;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'btnAddCoverage') and text()='Add']")]
        private IWebElement btnNewCoverage;

        [FindsBy(How = How.XPath, Using = "//table[@id='Table1']//table//tr[@class='PanelTitle tableHeader']")]
        private IWebElement tblCoverageHeader;

        [FindsBy(How = How.XPath, Using = "//table[@id='Table1']//table//tr[@class='PanelDetail']//td[15]//a")]
        private IWebElement lnkTBD;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'dnn_ctr1501_WorklistPanel_task_Task4_CoverageDetails_ddlStatus')]")]
        private IWebElement verificationStatus;

        [FindsBy(How = How.XPath, Using = "//a[text()='Update']")]
        private IWebElement btnUpdateVerifiedStatus;

        [FindsBy(How = How.XPath, Using = "//a[text()='Complete']")]
        private IWebElement btnComplete;

        /// <summary>
        /// Methhod to add new coverage in account
        /// </summary>
        /// <param name="CoverageType"></param>
        public void AddNewCoverage(string CoverageType)
        {
            try
            {
                if (covergeTblRows.Count > 0)
                {
                    int delBtnCnt = covergeTblRows.Count;
                    for (int i = 1; i <= delBtnCnt; i++)
                    {
                        IWebElement delele = DriverContext.driver.FindElement(By.XPath(delCoverageRows));
                        DriverContext.driver.ScrollInView(delele);
                        delele.Click();

                    }

                }
   
            }
            catch (NoSuchElementException e) { }
            DriverContext.driver.ScrollInView(txtSearchCoverage);
            if (CoverageType.Equals("Medicare", StringComparison.OrdinalIgnoreCase))
                txtSearchCoverage.SendKeys(Settings.MedicareCoverageType);
            if (CoverageType.Equals("NonMedicare",StringComparison.OrdinalIgnoreCase))
                txtSearchCoverage.SendKeys(Settings.AETNACovergaeType);

            btnFindCoverage.Click();
            SearchCoverage();
           
            ChangeCoverageStatus();

        }

        /// <summary>
        /// Method to search coverage
        /// </summary>
        public void SearchCoverage()
        {
            int searchEleCount = 0;
            foreach (IWebElement colHeader in serachResultCol)
            {
                searchEleCount++;
                if ((colHeader.Text).Equals(HeaderTypeCol, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }

            if (serachResultRows.Count > 1)
            {
                searchResult = DriverContext.driver.FindElement(By.XPath(searchRowLocator + "[" + toprow + "]/td[" + searchEleCount + "]")).Text;

                if (searchResult.Contains(Settings.MedicareCoverageType))
                    DriverContext.driver.FindElement(By.XPath(searchRowLocator + "[" + toprow + "]/td[" + toprow + "]//a")).Click();
                if (searchResult.Contains(Settings.AETNACovergaeType))
                   DriverContext.driver.FindElement(By.XPath(searchRowLocator + "[" + toprow + "]/td[" + toprow + "]//a")).Click();
            }
            btnNewCoverage.Click();

        }


        /// <summary>
        /// Method to change status of coverage 
        /// </summary>
        public void ChangeCoverageStatus()
        {
            if (tblCoverageHeader.Displayed)
            {
                lnkTBD.Click();
                DriverContext.driver.ScrollInView(verificationStatus);
                verificationStatus.ClickDropDownValuebyContainingText(passCoveragetatus);
                btnUpdateVerifiedStatus.Click();
            }
            else
            {
                Assert.True(false, "Coverage Not Added,table not found");
            }
        }


    }
}
