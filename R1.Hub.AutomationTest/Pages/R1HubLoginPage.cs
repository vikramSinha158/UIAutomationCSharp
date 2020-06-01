using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace R1.Hub.AutomationTest.Pages
{
    class R1HubLoginPage:BasePage
    {

        public R1HubLoginPage(ScenarioContext scenarioContext):base(scenarioContext)
        {
                
        }

        private IWebElement txtUserName = DriverContext.driver.FindElement(By.XPath("//input[contains(@id,'Username')]"));

        IWebElement txtPassword= DriverContext.driver.FindElement(By.XPath("//input[contains(@id,'Password')]"));

        IWebElement btnLogin = DriverContext.driver.FindElement(By.XPath("//a[contains(@id,'Login') and @title = 'Login']"));


        public void Login(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
        }

        public HomePage ClickLoginButton()
        {
            btnLogin.Click();
            return new HomePage(_scenarioContext);
            //return GetInstance<HomePage(_scenarioContext)>;
        }


        internal void CheckIfLoginExist()
        {
            
        }


    }
}
