﻿using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using R1.Automation.UI.core.Selenium.Extensions;
using R1.Hub.AutomationBase.Config;
using Xunit;


namespace R1.Hub.AutomationTest.Pages
{
    public class ServicesPage : BasePage
    {
        private string delRowsHCPCSelected = "//table[contains(@id,'grdHCPCSelected')]//tr[@class='PanelDetail']//td//a/img[@src='/images/delete.gif']";
        private string rowsHCPCSelected = "//table[contains(@id,'grdHCPCSelected')]//tr[@class='PanelDetail']";
        private string colHCPCSelected = "//table[contains(@id,'grdHCPCSelected')]//tr[@class='PanelTitle tableHeader']//td";
        private string delRowsICDSelected = "//table[contains(@id,'grdICD9Selected')]//tr[@class='PanelDetail']//td//a/img[@src='/images/delete.gif']";
        private string rowsICDSelected = "//table[contains(@id,'grdICD9Selected')]//tr[@class='PanelDetail']";
        private string colICDSelected = "//table[contains(@id,'grdICD9Selected')]//tr[@class='PanelTitle tableHeader']//td";

        public ServicesPage(DriverContext driverContext) : base(driverContext)
        {
            PageFactory.InitElements(driverContext.Driver, this);
        }

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

        /// <summary>
        /// Click on Addminting link in service
        /// </summary>
        public void ClickAddmittingServices()
        {          
            try
            {
                _driverContext.Driver.ScrollInView(lnkAdmiitingServices);
                lnkAdmiitingServices.Click();
            }
            catch (NoSuchElementException) { }
        }

        /// <summary>
        /// Click ob continue button
        /// </summary>
        public void ClicContinue()
        {
            try
            {
                btnComplete.Click();
            }
            catch (NoSuchElementException) { }

        }

        /// <summary>
        /// Add CPT code in srvice table
        /// </summary>
        public void AddServiceCode()
        {
            AddCode(delHCPCSelected, delRowsHCPCSelected, rowsHCPCSearch, firstRowHCPCSearch);
        }

        /// <summary>
        /// Add ICD code in Diagonosis table
        /// </summary>
        public void AddDiagnosisCode()
        {
            AddCode(delICDSelected, delRowsICDSelected, rowsICDSearch, firstRowICDSearch);
        }

        /// <summary>
        /// Get service code from table
        /// </summary>
        /// <returns></returns>
        public List<String> GetServiceCPTcode()
        {
            return util.GetColvalues(_driverContext.Driver,rowsHCPCSelected, colHCPCSelected, "HCPC");
        }

        /// <summary>
        /// Get ICD code from Diagonosis table
        /// </summary>
        /// <returns></returns>
        public List<String> GetDiagonosisCode()
        {
            return util.GetColvalues(_driverContext.Driver,rowsICDSelected, colICDSelected, "ICD");
        }

        /// <summary>
        /// Method to get code from table in service page
        /// </summary>
        /// <param name="delTblRowCnt"></param>
        /// <param name="xpathDelrow"></param>
        /// <param name="rowsSearchResultCnt"></param>
        /// <param name="firstRowSearchResult"></param>
        public void AddCode(IList<IWebElement> delTblRowCnt, string xpathDelrow, IList<IWebElement> rowsSearchResultCnt, IWebElement firstRowSearchResult)
        {
            _driverContext.Driver.ScrollInView(txtSearchService);

            try
            {
                if (delTblRowCnt.Count > 0)
                {
                    int delBtnCnt = delTblRowCnt.Count;
                    for (int i = 1; i <= delBtnCnt; i++)
                    {
                        IWebElement delele = _driverContext.Driver.FindElement(By.XPath(xpathDelrow));
                        delele.Click();
                        _driverContext.Driver.ScrollInView(txtSearchService);
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
                    _driverContext.Driver.ScrollInView(firstRowSearchResult);
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
