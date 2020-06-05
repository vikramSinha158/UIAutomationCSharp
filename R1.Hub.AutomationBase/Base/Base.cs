using OpenQA.Selenium;
using R1.Automation.UI.core.Commons;
using R1.Automation.UI.core.Selenium.Base;
using System;
using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration;


namespace R1.Hub.AutomationBase.Base
{
    public class Base
    {


        public readonly ScenarioContext _scenarioContext;
        public Base(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public BasePage CurrentPage
        {
            get => (BasePage)_scenarioContext["currentPage"];
            set => _scenarioContext["currentPage"] = value;
        }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
            
    }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }

        public CommonUtility commonUtil = new CommonUtility();

        //public static IConfigurationRoot config { get; set; }

    }
}
