using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using R1.Hub.AutomationBase.Base;
using R1.Hub.AutomationTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace R1.Hub.AutomationTest.StepDefinitions
{

    [Binding]
    class BusinessRulesStepDef:Base
    {

        //R1HubLoginPage login;
        private new ScenarioContext _scenarioContext;
        public BusinessRulesStepDef(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;

            //login = new R1HubLoginPage(_scenarioContext);
        }
        

        [Given(@"user is on R(.*)Access login page")]
        public void GivenUserIsOnRAccessLoginPage(int p0)
        {
            CurrentPage = new R1HubLoginPage(_scenarioContext);
 
            CurrentPage.As<R1HubLoginPage>().Login("Rsingh45", "Summer01*");
            CurrentPage=CurrentPage.As<R1HubLoginPage>().ClickLoginButton();

        }

        [When(@"user logins into the applicationoutcome]")]
        public void WhenUserLoginsIntoTheApplicationoutcome()
        {
            CurrentPage.As<HomePage>().ClickLogOut();
        }

    }
}
