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

        public PatientAccessPage(DriverContext driverContext) : base(driverContext)
        {
            PageFactory.InitElements(driverContext.Driver, this);
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
            return new PreRegistrationPage(_driverContext);
        }

        public ConversionFollowupPage ClickOnConversionFollowUp()
        {
            _driverContext.Driver.ScrollInView(lnkConversionFollowup);
            _driverContext.Driver.ClickOnElement(lnkConversionFollowup);
            return new ConversionFollowupPage(_driverContext);

        }



    }
}
