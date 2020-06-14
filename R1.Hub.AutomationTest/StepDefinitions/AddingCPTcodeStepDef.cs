﻿using R1.Hub.AutomationBase.Base;
using R1.Hub.AutomationTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using System.Threading;
using Xunit;
using R1.Hub.AutomationTest.Utility;

namespace R1.Hub.AutomationTest.StepDefinitions
{
    [Binding]
    public class AddingCPTcodeStepDef : BaseStep
    {
        private new ScenarioContext _scenarioContext;
        private AccountPage _accPage;
        List<String> listCPTcode;
        List<String> ListR1NessityCPT;

        public AddingCPTcodeStepDef(ScenarioContext scenarioContext,AccountPage accountPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _accPage = accountPage;

        }

        [When(@"user navigates to the Patient Access > Preregistrations worklist")]
        public void WhenUserNavigatesToThePatientAccessPreregistrationsWorklist()
        {
            //Thread.Sleep(10000);
            CurrentPage = CurrentPage.As<HomePage>().ClickPatientAccessTab();
            CurrentPage=CurrentPage.As<PatientAccessPage>().ClickOnPreRegistration();

        }

        [When(@"user open any account with Medicare coverage with passed status")]
        public void WhenUserOpenAnyAccountWithMedicareCoverageWithPassedStatus()
        {
            CurrentPage=CurrentPage.As<PreRegistrationPage>().ClickOnAccount();
            CurrentPage=CurrentPage.As<AccountPage>().ClickOnCoverageTab();

            //CurrentPage.As<CoveragePage>().ClickCheckOutAndRedo11();
            _accPage.ClickCheckOutAndRedo();
            CurrentPage.As<CoveragePage>().AddNewCoverage();

        }

        [When(@"user clicks on complete button")]
        public void WhenUserClicksOnCompleteButton()
        {
            //CurrentPage.As<CoveragePage>().ClickComplete();
            _accPage.ClickComplete();
        }

        [When(@"R(.*)Necesity tab is enabled on the account")]
        public void WhenRNecesityTabIsEnabledOnTheAccount(int p0)
        {
            Assert.True(_accPage.IsR1NecessityVisible(), "R1 Necessity is not visible ");
        }

        [When(@"user navigates to the services tab")]
        public void WhenUserNavigatesToTheServicesTab()
        {
            CurrentPage = _accPage.ClickOnServicesTab();
           
        }

        [When(@"user adds CPT code on the account")]
        public void WhenUserAddsCPTCodeOnTheAccount()
        {
            _accPage.ClickCheckOutAndRedo();
            //CurrentPage.As<ServicesPage>().ClickAddmittingServices();
            CurrentPage.As<ServicesPage>().ClickAddmittingServices();
            CurrentPage.As<ServicesPage>().AddServiceCode();
            listCPTcode= CurrentPage.As<ServicesPage>().GetServiceCPTcode();

        }

        [Then(@"An entry should get inserted into the R(.*)Necessity tab for each CPT code being added")]
        public void ThenAnEntryShouldGetInsertedIntoTheRNecessityTabForEachCPTCodeBeingAdded(int p0)
        {
            CurrentPage = _accPage.ClickOnR1Necessity();
            ListR1NessityCPT=CurrentPage.As<R1NecessityPage>().GetR1NessityCPT();
            bool cptSatus = new CommonLib().CompareList(listCPTcode, ListR1NessityCPT);
            Assert.True(cptSatus, "CPT code from service doesn't match with R1Necessity ");
        }







    }
}
