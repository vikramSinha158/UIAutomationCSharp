﻿using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using R1.Automation.UI.core.Selenium.Extensions;

namespace R1.Hub.AutomationTest.Pages
{
    class R1HubLoginPage:BasePage
    {

        public R1HubLoginPage(ScenarioContext scenarioContext):base(scenarioContext)
        {
            PageFactory.InitElements(DriverContext.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'Username')]")]
        private readonly IWebElement txtUserName;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'Password')]")]
        private IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'Login') and @title = 'Login']")]
        private IWebElement btnLogin;


        public void Login(string userName, string password)
        {
            txtUserName.Clear();
            txtUserName.SendKeys(userName);
            txtPassword.Clear();
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
