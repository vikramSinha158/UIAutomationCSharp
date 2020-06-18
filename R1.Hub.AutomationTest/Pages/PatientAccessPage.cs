using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;
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
            PageFactory.InitElements(DriverContext.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'Pre-Registration')]")]
        private IWebElement lnkPreRegistration;

 
        /// <summary>
        /// Click on pre registration link
        /// </summary>
        /// <returns></returns>
        public PreRegistrationPage ClickOnPreRegistration()
        {
            lnkPreRegistration.Click();

            return new PreRegistrationPage(_scenarioContext);
        }


    }
}
