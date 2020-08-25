using R1.Hub.AutomationBase.Base;
using R1.Hub.AutomationTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using R1.Hub.AutomationBase.Config;
using System.Data;
using Xunit;

namespace R1.Hub.AutomationTest.StepDefinitions
{
    [Binding]
    public class CWLStepDef:BaseStep
    {
        private new DriverContext _driverContext;
        private int totalWorkListRecordUI;
        private int totalworklistRecordDB;
        private Settings _settings;

        public CWLStepDef(DriverContext driverContex, Settings settings) : base(driverContex)
        {
            _driverContext = driverContex;
            _settings = settings;
        }

        [When(@"user clicks on Patient Access link")]
        public void WhenUserClicksOnPatientAccessLink()
        {
            _driverContext.CurrentPage = _driverContext.CurrentPage.As<HomePage>().ClickPatientAccessTab();       
        }

        [Given(@"user clicks on Conversion Followup worklist")]
        public void GivenUserClicksOnConversionFollowupWorklist()
        {
            _driverContext.CurrentPage = _driverContext.CurrentPage.As<PatientAccessPage>().ClickOnConversionFollowUp();
        }

        [When(@"user verify subfilter folder of conversion followup worklist")]
        public void WhenUserVerifySubfilterFolderOfConversionFollowupWorklist()
        {
            _driverContext.CurrentPage.As<ConversionFollowupPage>().VerifyConversionFollowDisplay();        
        }

        [Then(@"user should be able to view following subfilter folder tree in conversion followup worklist:")]
        public void ThenUserShouldBeAbleToViewFollowingSubfilterFolderTreeInConversionFollowupWorklist()
        {
            _driverContext.CurrentPage.As<ConversionFollowupPage>().verifyFilterFolder();      
        }

        [When(@"user clicks on ""(.*)"" filter folder")]
        public void WhenUserClicksOnFilterFolder(string filterFolder)
        {
            _driverContext.CurrentPage.As<ConversionFollowupPage>().ClickOnFilterfolder(filterFolder);
        }

        [Then(@"user should be able to view ""(.*)"" filter folder")]
        public void ThenUserShouldBeAbleToViewFilterFolder(string filterFolder)
        {
            _driverContext.CurrentPage.As<ConversionFollowupPage>().verifyFilterfolderName(filterFolder);
            totalWorkListRecordUI = _driverContext.CurrentPage.As<ConversionFollowupPage>().GetTotalWorkListRows();
        }

        [When(@"user connect to Tran database and fetch data from Tran database using DB query ""(.*)""")]
        public void WhenUserConnectToTranDatabaseAndFetchDataFromTranDatabaseUsingDBQuery(string querykey)
        {
            totalworklistRecordDB = util.GetTotalRowCountTable(_settings.DbConnection, querykey);
        }

        [Then(@"db query result count should be matched with I/S at Risk worklist count\.")]
        public void ThenDbQueryResultCountShouldBeMatchedWithISAtRiskWorklistCount_()
        {
            bool intStatus = util.CompareInteger(totalworklistRecordDB, totalWorkListRecordUI);
            Assert.True(intStatus, "Database value not match with UI record,Database record : " + totalworklistRecordDB + " and UI total record : " + totalWorkListRecordUI);
        }

        [When(@"user clicks on \+ button of Care Coverage filter folder")]
        public void WhenUserClicksOnButtonOfCareCoverageFilterFolder()
        {
            _driverContext.CurrentPage.As<ConversionFollowupPage>().ClickOnExpandCoveragecare();
        }

        [Then(@"following list of sub filter folders should be appear")]
        public void ThenFollowingListOfSubFilterFoldersShouldBeAppear(Table table)
        {
            _driverContext.CurrentPage.As<ConversionFollowupPage>().VeryfySubFilterFolderCoverageCare(table);
        }

        [When(@"user clicks on Coveragecare  ""(.*)"" sub filter folder")]
        public void WhenUserClicksOnCoveragecareSubFilterFolder(string coverageCarefilterFolder)
        {
            _driverContext.CurrentPage.As<ConversionFollowupPage>().ClickOnCoveraegCareFilterFolder(coverageCarefilterFolder);
        }


        [Given(@"user clicks on ""(.*)"" worklist")]
        public void GivenUserClicksOnWorklist(string p0)
        {
            _driverContext.CurrentPage = _driverContext.CurrentPage.As<PatientAccessPage>().ClickOnR1DetectWorkList();
        }

        [Given(@"user is on R(.*) detect worklist")]
        public void GivenUserIsOnRDetectWorklist(int p0)
        {
            _driverContext.CurrentPage = _driverContext.CurrentPage.As<R1DetectPage>().VerifyR1DetectWorklistDisplay();
        }

        [When(@"user open an account from worklist")]
        public void WhenUserOpenAnAccountFromWorklist()
        {
            _driverContext.CurrentPage = _driverContext.CurrentPage.As<ExtendedPage>().ClickOnAccount();
        }

        [When(@"user clicks on PFA tab")]
        public void WhenUserClicksOnPFATab()
        {
            _driverContext.CurrentPage.As<AccountPage>().ClickCheckOutAndRedo();
            _driverContext.CurrentPage = _driverContext.CurrentPage.As<AccountPage>().ClickOnPFA();
        }

        [When(@"user clicks on override tab")]
        public void WhenUserClicksOnOverrideTab()
        {
            _driverContext.CurrentPage.As<PFAPage>().ClickOnOverrideTab();
        }

        [When(@"user verify FollowUp Date field")]
        public void WhenUserVerifyFollowUpDateField()
        {
            _driverContext.CurrentPage.As<PFAPage>().VerifyDateFollowUpField();
        }


    }
}
