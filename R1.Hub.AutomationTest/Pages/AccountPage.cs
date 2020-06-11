using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

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

        public CoveragePage ClickOnCoverageTab()
        {
            coverageTab.Click();
            return new CoveragePage(_scenarioContext);
        }

    }
}
