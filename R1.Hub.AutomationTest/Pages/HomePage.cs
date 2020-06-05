using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;
using R1.Automation.UI.core.Selenium.Extensions;

namespace R1.Hub.AutomationTest.Pages
{
    public  class HomePage:BasePage
    {
        public HomePage(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }

        private readonly IWebElement txtLogout = DriverContext.driver.FindElement(By.XPath("//a[@title='Logout']"));

        private readonly IWebElement lnkPatientAccess = DriverContext.driver.FindElement(By.XPath("//span[contains(@class,'id52')]//a"));

        private readonly IWebElement lblHome = DriverContext.driver.FindElement(By.XPath("//a[contains(@href,'Home')]//span[text()='Home']"));

        public void ClickLogOut()=> txtLogout.Click();

        public PatientAccessPage ClickPatientAccessTab()
        {
           
            lnkPatientAccess.Click();
            return new PatientAccessPage(_scenarioContext);
        }

        public void VerifyHomePageVisible() {

            string ss = lblHome.Text;
            Assert.True(lblHome.Displayed, "Home Page not Visible");
        }
    }
}
