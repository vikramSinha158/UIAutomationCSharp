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
    class BusinessRulesStepDef: BaseStep
    {

        //R1HubLoginPage login;
        private new DriverContext _driverContext;
        public BusinessRulesStepDef(DriverContext driverContext) : base(driverContext)
        {
            _driverContext = driverContext;

        }
        

        [When(@"user logins into the applicationoutcome]")]
        public void WhenUserLoginsIntoTheApplicationoutcome()
        {
            _driverContext.CurrentPage.As<HomePage>().ClickLogOut();
        }

    }
}
