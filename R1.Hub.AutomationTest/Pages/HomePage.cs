using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace R1.Hub.AutomationTest.Pages
{
    public  class HomePage:BasePage
    {
        public HomePage(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }

        private IWebElement txtLogout = DriverContext.driver.FindElement(By.XPath("//a[@title='Logout']"));

        public void ClickLogOut()
        {
            txtLogout.Click();
            
        }
    }
}
