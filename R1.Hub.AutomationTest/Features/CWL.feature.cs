﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.3.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace R1.Hub.AutomationTest.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CWLFeature : object, Xunit.IClassFixture<CWLFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CWL.feature"
#line hidden
        
        public CWLFeature(CWLFeature.FixtureData fixtureData, R1_Hub_AutomationTest_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CWL", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line hidden
#line 4
  testRunner.Given("user is on R1 Hub login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 5
  testRunner.And("Select Facilty Code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 6
  testRunner.When("user clicks on Patient Access link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 7
  testRunner.Given("user clicks on Conversion Followup worklist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Verify filter folder in conversion Followup worklist")]
        [Xunit.TraitAttribute("FeatureTitle", "CWL")]
        [Xunit.TraitAttribute("Description", "Verify filter folder in conversion Followup worklist")]
        public virtual void VerifyFilterFolderInConversionFollowupWorklist()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify filter folder in conversion Followup worklist", null, tagsOfScenario, argumentsOfScenario);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 11
 testRunner.When("user verify subfilter folder of conversion followup worklist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 12
 testRunner.Then("user should be able to view following subfilter folder tree in conversion followu" +
                        "p worklist:", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Verify records in folder")]
        [Xunit.TraitAttribute("FeatureTitle", "CWL")]
        [Xunit.TraitAttribute("Description", "Verify records in folder")]
        [Xunit.TraitAttribute("Category", "DBConnection")]
        [Xunit.InlineDataAttribute("I/S at Risk", "CWL_433959_SQL1", new string[0])]
        [Xunit.InlineDataAttribute("E/O at Risk", "CWL_433960_SQL1", new string[0])]
        [Xunit.InlineDataAttribute("Future Follow Up", "CWL_433961_SQL1", new string[0])]
        [Xunit.InlineDataAttribute("Zero Balance", "CWL_433962_SQL1", new string[0])]
        [Xunit.InlineDataAttribute("Supervisor Worklist", "CWL_433963_SQL1", new string[0])]
        [Xunit.InlineDataAttribute("On-Deck", "CWL_433964_SQL1", new string[0])]
        [Xunit.InlineDataAttribute("BSO", "CWL_433965_SQL1", new string[0])]
        public virtual void VerifyRecordsInFolder(string filterFolder, string queryID, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DBConnection"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FilterFolder", filterFolder);
            argumentsOfScenario.Add("QueryID", queryID);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify records in folder", null, tagsOfScenario, argumentsOfScenario);
#line 17
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 18
 testRunner.When(string.Format("user clicks on \"{0}\" filter folder", filterFolder), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 19
 testRunner.Then(string.Format("user should be able to view \"{0}\" filter folder", filterFolder), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 20
 testRunner.When(string.Format("user connect to Tran database and fetch data from Tran database using DB query \"{" +
                            "0}\"", queryID), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 21
 testRunner.Then("db query result count should be matched with I/S at Risk worklist count.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Verify Care Coverage filter folder and it\'s sub-folders")]
        [Xunit.TraitAttribute("FeatureTitle", "CWL")]
        [Xunit.TraitAttribute("Description", "Verify Care Coverage filter folder and it\'s sub-folders")]
        [Xunit.TraitAttribute("Category", "DBConnection")]
        [Xunit.InlineDataAttribute("Care Coverage", "CWL_433966_SQL1", "On-Deck", "Pending", "CWL_433966_SQL2", "CWL_433966_SQL3", new string[0])]
        public virtual void VerifyCareCoverageFilterFolderAndItsSub_Folders(string filterFolder, string queryID, string coverageCareOnDeck, string coverageCarePending, string queryCoverageOnDeck, string queryCoveragePending, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DBConnection"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FilterFolder", filterFolder);
            argumentsOfScenario.Add("QueryID", queryID);
            argumentsOfScenario.Add("CoverageCareOnDeck", coverageCareOnDeck);
            argumentsOfScenario.Add("CoverageCarePending", coverageCarePending);
            argumentsOfScenario.Add("QueryCoverageOnDeck", queryCoverageOnDeck);
            argumentsOfScenario.Add("QueryCoveragePending", queryCoveragePending);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Care Coverage filter folder and it\'s sub-folders", null, tagsOfScenario, argumentsOfScenario);
#line 34
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 35
 testRunner.When(string.Format("user clicks on \"{0}\" filter folder", filterFolder), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 36
 testRunner.Then(string.Format("user should be able to view \"{0}\" filter folder", filterFolder), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 37
 testRunner.When(string.Format("user connect to Tran database and fetch data from Tran database using DB query \"{" +
                            "0}\"", queryID), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 38
 testRunner.Then("db query result count should be matched with I/S at Risk worklist count.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 39
    testRunner.When("user clicks on + button of Care Coverage filter folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "SubFilterFolderDeck",
                            "SubFilterFolderPending"});
                table1.AddRow(new string[] {
                            "On-Deck",
                            "Pending"});
#line 40
    testRunner.Then("following list of sub filter folders should be appear", ((string)(null)), table1, "Then ");
#line hidden
#line 43
    testRunner.When(string.Format("user clicks on Coveragecare  \"{0}\" sub filter folder", coverageCareOnDeck), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 44
    testRunner.Then(string.Format("user should be able to view \"{0}\" filter folder", coverageCareOnDeck), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 45
    testRunner.When(string.Format("user connect to Tran database and fetch data from Tran database using DB query \"{" +
                            "0}\"", queryCoverageOnDeck), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 46
    testRunner.Then("db query result count should be matched with I/S at Risk worklist count.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 47
     testRunner.When(string.Format("user clicks on Coveragecare  \"{0}\" sub filter folder", coverageCarePending), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 48
    testRunner.Then(string.Format("user should be able to view \"{0}\" filter folder", coverageCarePending), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
    testRunner.When(string.Format("user connect to Tran database and fetch data from Tran database using DB query \"{" +
                            "0}\"", queryCoveragePending), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 50
    testRunner.Then("db query result count should be matched with I/S at Risk worklist count.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CWLFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CWLFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion