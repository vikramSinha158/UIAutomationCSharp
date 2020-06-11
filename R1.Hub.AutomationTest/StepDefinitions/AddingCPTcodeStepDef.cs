using R1.Hub.AutomationBase.Base;
using R1.Hub.AutomationTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using System.Threading;

namespace R1.Hub.AutomationTest.StepDefinitions
{
    [Binding]
    public class AddingCPTcodeStepDef : BaseStep
    {

        private new ScenarioContext _scenarioContext;
        public AddingCPTcodeStepDef(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }

        [When(@"user navigates to the Patient Access > Preregistrations worklist")]
        public void WhenUserNavigatesToThePatientAccessPreregistrationsWorklist()
        {
            Thread.Sleep(10000);
            CurrentPage = CurrentPage.As<HomePage>().ClickPatientAccessTab();
            CurrentPage=CurrentPage.As<PatientAccessPage>().ClickOnPreRegistration();

        }

        [When(@"user open any account with Medicare coverage with passed status")]
        public void WhenUserOpenAnyAccountWithMedicareCoverageWithPassedStatus()
        {
            CurrentPage=CurrentPage.As<PreRegistrationPage>().ClickOnAccount();
            CurrentPage=CurrentPage.As<AccountPage>().ClickOnCoverageTab();

            CurrentPage.As<CoveragePage>().ClickCheckOutAndRedo();
            CurrentPage.As<CoveragePage>().AddNewCoverage();

        }


    }
}
