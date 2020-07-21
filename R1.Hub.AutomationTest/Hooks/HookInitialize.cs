
using R1.Hub.AutomationBase.Base;
using R1.Hub.AutomationBase.Config;
using R1.Hub.AutomationTest.TestData;
using TechTalk.SpecFlow;


namespace R1.Hub.AutomationTest.Hooks
{

    [Binding]
    public class HookInitialize: TestInitializeHook
    {    
        private readonly ScenarioContext _scenariocontext;
        private Settings _settings;
        private DriverContext _driverContext;


        public HookInitialize(DriverContext driverContext,ScenarioContext scenarioContext, Settings settings) : base(driverContext)
        {
            _driverContext = driverContext;
            _scenariocontext = scenarioContext;
            _settings = settings;


        }

        [BeforeTestRun]
        public static void TestRun()
        {
            InitializeSettings();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            
            GetFeatureInfo(featureContext);

        }

        [BeforeScenario]
        public void TestInitalize()
        {
            DataReader.SetTestData();
            InitializeDriver();
            NaviateSite();
            GetScenarioInfo(_scenariocontext);
        }

        [BeforeScenario("DBConnection")]
        public void CreateDBConnection()
        {
            string tranStr = _settings.TranDBcon.GetTranConnectionString(Settings.FacilatyCode);
           _settings.DbConnection = _settings.DataAccess.ConnectToDB(tranStr);
        }

        [AfterScenario]
        public void AfterScenario()
        {
           _settings.DataAccess.CloseDBConnection();
            _driverContext.Driver.Quit();

        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            GetStepInfo(_scenariocontext);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            PublishReport();
            CloseBrowser();


        }
    }
}
