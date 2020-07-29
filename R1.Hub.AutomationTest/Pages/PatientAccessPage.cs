using OpenQA.Selenium;
using R1.Automation.UI.core.Selenium.Extensions;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;

namespace R1.Hub.AutomationTest.Pages
{
    public class PatientAccessPage:BasePage
    {
        private string conversionFollow = "//a/span[text()='Conversion Followup']";

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

        /// <summary>
        /// Click On Conversion FollowUp
        /// </summary>
        /// <returns>Conversion Followup Page</returns>
        public ConversionFollowupPage ClickOnConversionFollowUp()
        {
            _driverContext.Driver.ScrollInView(lnkConversionFollowup);
            _driverContext.Driver.ClickOnElement(lnkConversionFollowup);
            return new ConversionFollowupPage(_driverContext);
        }
    }
}
