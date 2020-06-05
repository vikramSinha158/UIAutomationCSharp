using R1.Hub.AutomationBase.Base;
using R1.Hub.AutomationBase.Config;
using R1.Hub.AutomationTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace R1.Hub.AutomationTest.StepDefinitions
{
    [Binding]
    public class ExtendedSteps: BaseStep
    {
        private new ScenarioContext _scenarioContext;
        public ExtendedSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }

        //[Given(@"user is on R(.*)Access login page")]
        //public void GivenUserIsOnRAccessLoginPage(int p0)
        //{
        //    CurrentPage = new R1HubLoginPage(_scenarioContext);

        //    CurrentPage.As<R1HubLoginPage>().Login(Settings.UserName, Settings.Password);
        //    CurrentPage = CurrentPage.As<R1HubLoginPage>().ClickLoginButton();
        //}

        [Given(@"user is on R(.*) Hub login page")]
        public void GivenUserIsOnRHubLoginPage(int p0)
        {
            CurrentPage = new R1HubLoginPage(_scenarioContext);

            CurrentPage.As<R1HubLoginPage>().Login(Settings.UserName, Settings.Password);
            CurrentPage = CurrentPage.As<R1HubLoginPage>().ClickLoginButton();
        }

        [Given(@"user is on home page of the application")]
        public void GivenUserIsOnHomePageOfTheApplication()
        {
            CurrentPage.As<HomePage>().VerifyHomePageVisible();
        }

     


    }
}
