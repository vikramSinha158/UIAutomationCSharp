using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace R1.Hub.AutomationTest.Pages
{
    public class PatientAccessPage:BasePage
    {
        public PatientAccessPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }

        private readonly IWebElement lnkPreRegistration = DriverContext.driver.FindElement(By.XPath("//a[contains(@href,'Pre-Registration')]"));

        public void ClickOnPreRegistration()
        {
            lnkPreRegistration.Click();
        }


    }
}
