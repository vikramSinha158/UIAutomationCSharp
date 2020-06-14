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

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'lnkViewMode') and text()='Admitting']")]
        private IWebElement lnkAdmiitingServices;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtSearch')]")]
        private IWebElement txtSearchService;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'btnSearch')]")]
        private IWebElement btnSearchService;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'grdHCPCSearchResults_btnSelectHCPC')]")]
        private IList<IWebElement> rowsHCPCSearch;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'grdHCPCSearchResults_btnSelectHCPC')][1]")]
        private IWebElement firstRowHCPCSearch;

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'grdHCPCSelected')]//tr[@class='PanelDetail']")]
        private IList<IWebElement> delHCPCSelected;


        public void ClickAddmittingServices()
        {
            DriverContext.driver.ScrollInView(lnkAdmiitingServices);
            try
            {
                lnkAdmiitingServices.Click();
            }
            catch (NoSuchElementException) { }
            
        }

        public void AddServiceCode()
        {
            DriverContext.driver.ScrollInView(txtSearchService);

            try
            {
                if (delHCPCSelected.Count > 0)
                {
                    int delBtnCnt = delHCPCSelected.Count;
                    for (int i = 1; i <= delBtnCnt; i++)
                    {
                        IWebElement delele = DriverContext.driver.FindElement(By.XPath(delRowsHCPCSelected));
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
                if (rowsHCPCSearch.Count > 1)
                {
                    DriverContext.driver.ScrollInView(firstRowHCPCSearch);
                    firstRowHCPCSearch.Click();
                }
            }
            catch (NoSuchElementException ) 
            {
                Assert.True(false, "Not CPT found for " + Settings.SerachServiceCode + "please Check data ");
            }

 


        }

        public List<String> GetServiceCPTcode()
        {
            return new CommonLib().GetColvalues(rowsHCPCSelected, colHCPCSelected, "HCPC");
        }


    }
}
