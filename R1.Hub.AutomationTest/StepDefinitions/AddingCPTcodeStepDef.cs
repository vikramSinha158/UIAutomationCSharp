using R1.Hub.AutomationBase.Base;
using R1.Hub.AutomationTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

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
            CurrentPage = CurrentPage.As<HomePage>().ClickPatientAccessTab();
            CurrentPage.As<PatientAccessPage>().ClickOnPreRegistration();

        }

    }
}
