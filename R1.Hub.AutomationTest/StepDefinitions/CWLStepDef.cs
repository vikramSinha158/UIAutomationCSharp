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

        private new ScenarioContext _scenarioContext;
        private int totalWorkListRecordUI;
        private int totalworklistRecordDB;

        private Settings _settings;

        public CWLStepDef(ScenarioContext scenarioContext, Settings settings) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _settings = settings;
        }

        [When(@"user clicks on Patient Access link")]
        public void WhenUserClicksOnPatientAccessLink()
        {
            CurrentPage = CurrentPage.As<HomePage>().ClickPatientAccessTab();
        
        }

        [Given(@"user clicks on Conversion Followup worklist")]
        public void GivenUserClicksOnConversionFollowupWorklist()
        {
            CurrentPage = CurrentPage.As<PatientAccessPage>().ClickOnConversionFollowUp();

        }

        [When(@"user verify subfilter folder of conversion followup worklist")]
        public void WhenUserVerifySubfilterFolderOfConversionFollowupWorklist()
        {
            CurrentPage.As<ConversionFollowupPage>().VerifyConversionFollowDisplay();
           
        }

        [Then(@"user should be able to view following subfilter folder tree in conversion followup worklist:")]
        public void ThenUserShouldBeAbleToViewFollowingSubfilterFolderTreeInConversionFollowupWorklist()
        {
            CurrentPage.As<ConversionFollowupPage>().verifyFilterFolder();
       
        }

        [When(@"user clicks on ""(.*)"" filter folder")]
        public void WhenUserClicksOnFilterFolder(string filterFolder)
        {
            CurrentPage.As<ConversionFollowupPage>().ClickOnFilterfolder(filterFolder);
        }

        [Then(@"user should be able to view ""(.*)"" filter folder")]
        public void ThenUserShouldBeAbleToViewFilterFolder(string filterFolder)
        {
            CurrentPage.As<ConversionFollowupPage>().verifyFilterfolderName(filterFolder);
            totalWorkListRecordUI = CurrentPage.As<ConversionFollowupPage>().GetTotalWorkListRows();
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
            Assert.True(intStatus, "Database value not match with UI record,Database record : " + totalworklistRecordDB + "and UI total record : " + totalWorkListRecordUI);
        }

        [When(@"user clicks on \+ button of Care Coverage filter folder")]
        public void WhenUserClicksOnButtonOfCareCoverageFilterFolder()
        {
            CurrentPage.As<ConversionFollowupPage>().ClickOnExpandCoveragecare();
        }

        [Then(@"following list of sub filter folders should be appear")]
        public void ThenFollowingListOfSubFilterFoldersShouldBeAppear(Table table)
        {
            CurrentPage.As<ConversionFollowupPage>().VeryfySubFilterFolderCoverageCare(table);

        }

        [When(@"user clicks on Coveragecare  ""(.*)"" sub filter folder")]
        public void WhenUserClicksOnCoveragecareSubFilterFolder(string coverageCarefilterFolder)
        {

            CurrentPage.As<ConversionFollowupPage>().ClickOnCoveraegCareFilterFolder(coverageCarefilterFolder);
        }







    }
}
