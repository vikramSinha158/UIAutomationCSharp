using System;
using OpenQA.Selenium;
using R1.Automation.UI.core.Selenium.Extensions;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;

namespace R1.Hub.AutomationTest.Pages
{
    public class PFAPage : BasePage
    {
        public PFAPage(DriverContext driverContext) : base(driverContext)
        {
            PageFactory.InitElements(driverContext.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Override']")]
        private IWebElement overrideTab;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtFollowUpDate')]//preceding-sibling::text()[1]")]
        private IWebElement followUpDateLabel;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnSaveCWL')]")]
        private IWebElement saveButton;

        public void ClickOnOverrideTab()
        {
            overrideTab.Click();
        }

        public void VerifyDateFollowUpField()
        {
            _driverContext.Driver.PageScrollDown();
           // saveButton.Click();
           // _driverContext.Driver.ScrollInView(followUpDateLabel);
            util.IsDisplayed(followUpDateLabel);
        }
    }
}
