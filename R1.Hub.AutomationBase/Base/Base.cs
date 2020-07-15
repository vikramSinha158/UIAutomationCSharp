using OpenQA.Selenium;
using R1.Automation.UI.core.Commons;
using R1.Automation.UI.core.Selenium.Base;
using System;
using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration;
using R1.Hub.AutomationBase.Common;

namespace R1.Hub.AutomationBase.Base
{
    public class Base
    {


        public readonly ScenarioContext _scenarioContext;
        public Base(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Creating current page property
        /// </summary>
        public BasePage CurrentPage
        {
            get => (BasePage)_scenarioContext["currentPage"];
            set => _scenarioContext["currentPage"] = value;
        }

        /// <summary>
        /// Genric method to create object of class
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns></returns>
        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {

            return (TPage)Activator.CreateInstance(typeof(TPage));
            
        }
        /// <summary>
        /// Generic method to create instance of class
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns></returns>
        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }

        public CommonUtility commonUtil = new CommonUtility();

        public Utils util = new Utils();

    }
}
