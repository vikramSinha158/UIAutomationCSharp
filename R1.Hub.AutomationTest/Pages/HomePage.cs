using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;
using R1.Automation.UI.core.Selenium.Extensions;
using SeleniumExtras.PageObjects;

namespace R1.Hub.AutomationTest.Pages
{
    public  class HomePage:BasePage
    {
        public HomePage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            PageFactory.InitElements(DriverContext.driver, this);
        }

        private readonly string lnkPatientAccess = "//span[contains(@class,'id52')]//a";

        [FindsBy(How = How.XPath, Using = "//a[@title='Logout']")]
        private IWebElement txtLogout;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'Home')]//span[text()='Home']")]
        private IWebElement lblHome;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'LocationChooser_hypLoc')]")]
        private IWebElement lnkFacilityCode;

        [FindsBy(How = How.XPath, Using = "//Select[contains(@name,'LocationChooser$ddlLocation')]")]
        private IWebElement dropDwnFacilityCode;

        public void ClickLogOut()=> txtLogout.Click();

        public void ClickFaciclityCode() => lnkFacilityCode.Click();

        public void SelectFacilityCode(string text)
        {

            dropDwnFacilityCode.ClickDropDownValuebyContainingText(text);
        }

        public PatientAccessPage ClickPatientAccessTab()
        {
            DriverContext.driver.FindElement(By.XPath(lnkPatientAccess)).Click();
            //lnkPatientAccess.Click();
            return new PatientAccessPage(_scenarioContext);
        }

        public void VerifyHomePageVisible() {

            string ss = lblHome.Text;
            Assert.True(lblHome.Displayed, "Home Page not Visible");
        }
    }
}
