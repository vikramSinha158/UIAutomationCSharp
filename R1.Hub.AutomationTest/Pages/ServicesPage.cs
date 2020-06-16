using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using R1.Automation.UI.core.Selenium.Extensions;
using R1.Hub.AutomationBase.Config;
using Xunit;
using System.Threading;
using R1.Hub.AutomationTest.Utility;

namespace R1.Hub.AutomationTest.Pages
{
    public class ServicesPage : BasePage
    {
        public ServicesPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            PageFactory.InitElements(DriverContext.driver, this);
        }

        
        private string delRowsHCPCSelected = "//table[contains(@id,'grdHCPCSelected')]//tr[@class='PanelDetail']//td//a/img[@src='/images/delete.gif']";
        private string rowsHCPCSelected = "//table[contains(@id,'grdHCPCSelected')]//tr[@class='PanelDetail']";
        private string colHCPCSelected = "//table[contains(@id,'grdHCPCSelected')]//tr[@class='PanelTitle tableHeader']//td";
        private string delRowsICDSelected = "//table[contains(@id,'grdICD9Selected')]//tr[@class='PanelDetail']//td//a/img[@src='/images/delete.gif']";
        private string rowsICDSelected = "//table[contains(@id,'grdICD9Selected')]//tr[@class='PanelDetail']";
        private string colICDSelected = "//table[contains(@id,'grdICD9Selected')]//tr[@class='PanelTitle tableHeader']//td";

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'lnkViewMode') and text()='Admitting']")]
        private IWebElement lnkAdmiitingServices;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtSearch')]")]
        private IWebElement txtSearchService;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'btnSearch')]")]
        private IWebElement btnSearchService;

        [FindsBy(How = How.XPath, Using = "//a[ text()='Continue']")]
        private IWebElement btnComplete;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'grdHCPCSearchResults_btnSelectHCPC')]")]
        private IList<IWebElement> rowsHCPCSearch;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'grdHCPCSearchResults_btnSelectHCPC')][1]")]
        private IWebElement firstRowHCPCSearch;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'grdHCPCSelected')]//tr[@class='PanelDetail']")]
        private IList<IWebElement> delHCPCSelected;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'grdICD9Selected')]//tr[@class='PanelDetail']")]
        private IList<IWebElement> delICDSelected;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'grdICD9SearchResults')]")]
        private IList<IWebElement> rowsICDSearch;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'grdICD9SearchResults')][1]")]
        private IWebElement firstRowICDSearch;


        public void ClickAddmittingServices()
        {
            DriverContext.driver.ScrollInView(lnkAdmiitingServices);
            try
            {
                lnkAdmiitingServices.Click();
            }
            catch (NoSuchElementException) { }
            
        }

        public void ClicContinue()
        {
            
            try
            {
                btnComplete.Click();
            }
            catch (NoSuchElementException) { }

        }

        public void AddServiceCode()
        {
            AddCode(delHCPCSelected, delRowsHCPCSelected, rowsHCPCSearch, firstRowHCPCSearch);
            //AddCode(delICDSelected, delRowsICDSelected, rowsICDSearch, firstRowICDSearch);
            //DriverContext.driver.ScrollInView(txtSearchService);

            //try
            //{
            //    if (delHCPCSelected.Count > 0)
            //    {
            //        int delBtnCnt = delHCPCSelected.Count;
            //        for (int i = 1; i <= delBtnCnt; i++)
            //        {
            //            IWebElement delele = DriverContext.driver.FindElement(By.XPath(delRowsHCPCSelected));
            //            delele.Click();
            //            DriverContext.driver.ScrollInView(txtSearchService);
            //        }

            //    }

            //}
            //catch (NoSuchElementException) { }
            //txtSearchService.SendKeys(Settings.SerachServiceCode);
            //btnSearchService.Click();

            //try
            //{
            //    if (rowsHCPCSearch.Count > 1)
            //    {
            //        DriverContext.driver.ScrollInView(firstRowHCPCSearch);
            //        firstRowHCPCSearch.Click();
            //    }
            //}
            //catch (NoSuchElementException ) 
            //{
            //    Assert.True(false, "Not CPT found for " + Settings.SerachServiceCode + "please Check data ");
            //}

        }

        public void AddDiagnosisCode()
        {
            AddCode(delICDSelected, delRowsICDSelected, rowsICDSearch, firstRowICDSearch);
        }

        public List<String> GetServiceCPTcode()
        {
            return new CommonLib().GetColvalues(rowsHCPCSelected, colHCPCSelected, "HCPC");
        }

        public List<String> GetDiagonosisCode()
        {
            return new CommonLib().GetColvalues(rowsICDSelected, colICDSelected, "ICD");
        }

        public void AddCode(IList<IWebElement> delTblRowCnt, string xpathDelrow, IList<IWebElement> rowsSearchResultCnt, IWebElement firstRowSearchResult)
        {
            DriverContext.driver.ScrollInView(txtSearchService);

            try
            {
                if (delTblRowCnt.Count > 0)
                {
                    int delBtnCnt = delTblRowCnt.Count;
                    for (int i = 1; i <= delBtnCnt; i++)
                    {
                        IWebElement delele = DriverContext.driver.FindElement(By.XPath(xpathDelrow));
                        delele.Click();
                        DriverContext.driver.ScrollInView(txtSearchService);
                    }

                }

            }
            catch (NoSuchElementException) { }
            txtSearchService.SendKeys(Settings.SerachServiceCode);
            btnSearchService.Click();

            try
            {
                if (rowsSearchResultCnt.Count > 1)
                {
                    DriverContext.driver.ScrollInView(firstRowSearchResult);
                    firstRowSearchResult.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Assert.True(false, "Not CPT found for " + Settings.SerachServiceCode + "please Check data ");
            }
        }

    }
}
