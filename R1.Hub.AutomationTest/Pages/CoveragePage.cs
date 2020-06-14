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

        private string HeaderTypeCol = "Type";
        private readonly int toprow = 1;
        private readonly int verifiedHeader = 15;
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

        [FindsBy(How = How.XPath, Using = "//table[@id='Table1']//table//tr[@class='PanelDetail']//td//a//img[@title='Delete']")]
        private IList<IWebElement> btnCovergeDel;

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

        public void ClickCheckOutAndRedo11()
        {
            try
            {
                if (btnCheckOut.Displayed == true)
                    btnCheckOut.Click();
                if (btnRedo.Displayed == true)
                    btnRedo.Click();
            }
            catch (NoSuchElementException e)
            { }
        }

        public void AddNewCoverage()
        {
            try
            {
                foreach (IWebElement delBtn in btnCovergeDel)
                {
                    delBtn.Click();
                }
            }
            catch (NoSuchElementException e) { }
            txtSearchCoverage.SendKeys(Settings.SerachCoverageType);
            btnFindCoverage.Click();
            SearchCoverage();
            btnNewCoverage.Click();
            ChangeCoverageStatus();

        }

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

                if (searchResult.Contains(Settings.SerachCoverageType))
                    DriverContext.driver.FindElement(By.XPath(searchRowLocator + "[" + toprow + "]/td[" + toprow + "]//a")).Click();
            }

        }

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

        //public void ClickComplete()
        //{
        //    btnComplete.Click();
        //}
    }
}
