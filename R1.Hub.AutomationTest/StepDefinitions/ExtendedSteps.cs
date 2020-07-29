using R1.Hub.AutomationBase.Base;
using R1.Hub.AutomationBase.Config;
using R1.Hub.AutomationTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using R1.Automation.Database.core.Base;
using R1.Hub.AutomationBase.Common;

namespace R1.Hub.AutomationTest.StepDefinitions
{
    [Binding]
    public class ExtendedSteps: BaseStep
    {
        private new DriverContext _driverContext;

        public ExtendedSteps(DriverContext driverContex) : base(driverContex)
        {
            _driverContext = driverContex; 
        }

        [Given(@"user is on R(.*) Hub login page")]
        public void GivenUserIsOnRHubLoginPage(int p0)
        {
            _driverContext.CurrentPage = new R1HubLoginPage(_driverContext);
            _driverContext.CurrentPage.As<R1HubLoginPage>().Login(Settings.UserName, Settings.Password);
            _driverContext.CurrentPage = _driverContext.CurrentPage.As<R1HubLoginPage>().ClickLoginButton();
        }
    
        [Given(@"user is on home page of the application")]
        public void GivenUserIsOnHomePageOfTheApplication()
        {
            _driverContext.CurrentPage.As<HomePage>().VerifyHomePageVisible();
        }

        [Given(@"Select Facilty Code")]
        public void GivenSelectFaciltyCode()
        {
            _driverContext.CurrentPage.As<HomePage>().ClickFaciclityCode();
            _driverContext.CurrentPage.As<HomePage>().SelectFacilityCode(Settings.FacilatyCode);          
        }
     
        [AfterScenario]
        public void AppLogOut()
        {
            new HomePage(_driverContext).ClickLogOut();        
        }






    }
}
