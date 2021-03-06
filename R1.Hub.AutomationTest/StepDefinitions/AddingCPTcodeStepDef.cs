﻿using R1.Hub.AutomationBase.Base;
using R1.Hub.AutomationTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using System.Threading;
using Xunit;

namespace R1.Hub.AutomationTest.StepDefinitions
{
    [Binding]
    public class AddingCPTcodeStepDef : BaseStep
    {
        private new DriverContext _driverContext;
        private AccountPage _accPage;
        List<String> listCPTcode;
        List<String> ListR1NessityCPT;
        List<String> listDiagonsiscode;

        public AddingCPTcodeStepDef(DriverContext driverContex, AccountPage accountPage) : base(driverContex)
        {
            _driverContext = driverContex;
            _accPage = accountPage;      
        }

        [When(@"user navigates to the Patient Access > Preregistrations worklist")]
        public void WhenUserNavigatesToThePatientAccessPreregistrationsWorklist()
        {
            //Thread.Sleep(10000);
            _driverContext.CurrentPage = _driverContext.CurrentPage.As<HomePage>().ClickPatientAccessTab();
            _driverContext.CurrentPage = _driverContext.CurrentPage.As<PatientAccessPage>().ClickOnPreRegistration();
        }

        [When(@"user open any account with ""(.*)"" coverage with passed status")]
        public void WhenUserOpenAnyAccountWithCoverageWithPassedStatus(string CoverageType)
        {
            _driverContext.CurrentPage = _driverContext.CurrentPage.As<PreRegistrationPage>().ClickOnAccount();
            _driverContext.CurrentPage = _driverContext.CurrentPage.As<AccountPage>().ClickOnCoverageTab();
            _accPage.ClickCheckOutAndRedo();
            _driverContext.CurrentPage.As<CoveragePage>().AddNewCoverage(CoverageType);
        }

        [When(@"user clicks on complete button")]
        public void WhenUserClicksOnCompleteButton()
        {
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
            _driverContext.CurrentPage = _accPage.ClickOnServicesTab();
        }

        [When(@"user adds CPT code on the account")]
        public void WhenUserAddsCPTCodeOnTheAccount()
        {
            _accPage.ClickCheckOutAndRedo();
            _driverContext.CurrentPage.As<ServicesPage>().ClickAddmittingServices();
            _driverContext.CurrentPage.As<ServicesPage>().AddServiceCode();
            listCPTcode = _driverContext.CurrentPage.As<ServicesPage>().GetServiceCPTcode();
        }

        [Then(@"An entry should get inserted into the R(.*)Necessity tab for each CPT code being added")]
        public void ThenAnEntryShouldGetInsertedIntoTheRNecessityTabForEachCPTCodeBeingAdded(int p0)
        {
            _driverContext.CurrentPage = _accPage.ClickOnR1Necessity();
            ListR1NessityCPT = _driverContext.CurrentPage.As<R1NecessityPage>().GetR1NessityCPT();
            bool cptSatus = util.CompareList(listCPTcode, ListR1NessityCPT);
            Assert.True(cptSatus, "CPT code from service doesn't match with R1Necessity ");
        }

        [When(@"User Clic on Continue button")]
        public void WhenUserClicOnContinueButton()
        {
            _driverContext.CurrentPage.As<ServicesPage>().ClicContinue();
        }

        [Then(@"R(.*)Necesity tab should not get displayed on the account")]
        public void ThenRNecesityTabShouldNotGetDisplayedOnTheAccount(int p0)
        {
            Assert.False(_accPage.IsR1NecessityVisible(), "R1 Necessity is visible ");
        }

        [When(@"user adds diagnosis code on the account")]
        public void WhenUserAddsDiagnosisCodeOnTheAccount()
        {
            _accPage.ClickCheckOutAndRedo();
            _driverContext.CurrentPage.As<ServicesPage>().ClickAddmittingServices();
            _driverContext.CurrentPage.As<ServicesPage>().AddDiagnosisCode();
            listDiagonsiscode = _driverContext.CurrentPage.As<ServicesPage>().GetDiagonosisCode();
        }

        [Then(@"entry should not get inserted into the R(.*)Necessity tab")]
        public void ThenEntryShouldNotGetInsertedIntoTheRNecessityTab(int p0)
        {
            _driverContext.CurrentPage = _accPage.ClickOnR1Necessity();
            ListR1NessityCPT = _driverContext.CurrentPage.As<R1NecessityPage>().GetR1NessityCPT();
            bool containSatus = util.CheckContainList(ListR1NessityCPT, listDiagonsiscode);
            Assert.False(containSatus, "Diagonosis code from service contain match with R1Necessity ");
        }











    }
}
