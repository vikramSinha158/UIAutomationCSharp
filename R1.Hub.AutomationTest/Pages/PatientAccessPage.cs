using OpenQA.Selenium;
using R1.Automation.UI.core.Selenium.Extensions;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;

namespace R1.Hub.AutomationTest.Pages
{
    public class PatientAccessPage:BasePage
    {

        string conversionFollow = "//a/span[text()='Conversion Followup']";

        public PatientAccessPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            PageFactory.InitElements(DriverContext.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'Pre-Registration')]")]
        private IWebElement lnkPreRegistration;

        [FindsBy(How = How.XPath, Using = "//a/span[text()='Conversion Followup']")]
        private IWebElement lnkConversionFollowup;


        /// <summary>
        /// Click on pre registration link
        /// </summary>
        /// <returns></returns>
        public PreRegistrationPage ClickOnPreRegistration()
        {
            lnkPreRegistration.Click();

            return new PreRegistrationPage(_scenarioContext);
        }

        public ConversionFollowupPage ClickOnConversionFollowUp()
        {
            DriverContext.driver.ScrollInView(lnkConversionFollowup);
            DriverContext.driver.ClickOnElement(lnkConversionFollowup);
            return new ConversionFollowupPage(_scenarioContext);

        }



        //public void ClickOnPatientAccessWorklist(string linkTxt)
        //{
        //    DriverContext.driver.FindElement(By.XPath("//a/span[text()='" + linkTxt + "']")).Click();
        //}


    }
}
