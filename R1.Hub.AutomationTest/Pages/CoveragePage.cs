using R1.Hub.AutomationBase.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using R1.Automation.UI.core.Selenium.Extensions;
using SeleniumExtras.PageObjects;
using R1.Hub.AutomationBase.Config;

namespace R1.Hub.AutomationTest.Pages
{
    public class CoveragePage:BasePage
    {
        public CoveragePage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            PageFactory.InitElements(DriverContext.driver, this);
        }

        private string HeaderTypeCol = "Type";
        private readonly int toprow = 1;
        private string searchResult = String.Empty;
        private string searchRowLocator = "//table[contains(@id,'grdCoverageSearchResults')]//tr[@class='PanelDetail']";

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

        public void ClickCheckOutAndRedo()
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

        }

        public void SearchCoverage()
        {
            int searchEleCount=0;
            foreach (IWebElement colHeader in serachResultCol)
            {
                searchEleCount++;
                if ((colHeader.Text).Equals(HeaderTypeCol,StringComparison.OrdinalIgnoreCase))
                    {
                       break;
                    }
            }

            if(serachResultRows.Count>1)
            {
                searchResult = DriverContext.driver.FindElement(By.XPath(searchRowLocator + "[" + toprow + "]/td[" + searchEleCount + "]")).Text;

                if (searchResult.Contains(Settings.SerachCoverageType))
                    DriverContext.driver.FindElement(By.XPath(searchRowLocator + "[" + toprow + "]/td[" + toprow + "]//a")).Click();
            }

        }





    }
}
