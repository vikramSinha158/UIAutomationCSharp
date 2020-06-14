using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace R1.Hub.AutomationTest.Pages
{
    public class AccountPage : BasePage
    {
        public AccountPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            PageFactory.InitElements(DriverContext.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Coverage']")]
        private IWebElement coverageTab;

        [FindsBy(How = How.XPath, Using = "//a[text()='R1 Necessity™']")]
        private IWebElement R1NecessityTab;

        [FindsBy(How = How.XPath, Using = "//a[text()='Services']")]
        private IWebElement serviceTab;

        [FindsBy(How = How.XPath, Using = "//a[text()='Check Out']")]
        private IWebElement btnCheckOut;

        [FindsBy(How = How.XPath, Using = "//a[text()='Redo']")]
        private IWebElement btnRedo;

        [FindsBy(How = How.XPath, Using = "//a[text()='Complete']")]
        private IWebElement btnComplete;

        public CoveragePage ClickOnCoverageTab()
        {
            coverageTab.Click();
            return new CoveragePage(_scenarioContext);
        }

        public bool IsR1NecessityVisible()
        {
            return R1NecessityTab.Displayed;
        }

        public ServicesPage ClickOnServicesTab()
        {
            serviceTab.Click();
            return new ServicesPage(_scenarioContext);
        }

        public R1NecessityPage ClickOnR1Necessity()
        {
            R1NecessityTab.Click();
            return new R1NecessityPage(_scenarioContext);
        }

        public void ClickCheckOutAndRedo()
        {
            try
            {
                if (btnCheckOut.Displayed == true)
                    btnCheckOut.Click();
              
            }
            catch (NoSuchElementException e)
            { }
            try {
                if (btnRedo.Displayed == true)
                    btnRedo.Click();
            }
            catch (NoSuchElementException e)
            { }



        }

        public void ClickComplete()
        {
            btnComplete.Click();
        }

    }
}
