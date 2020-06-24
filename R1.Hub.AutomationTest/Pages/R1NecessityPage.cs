﻿using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace R1.Hub.AutomationTest.Pages
{
    public class R1NecessityPage:BasePage
    {
        public R1NecessityPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            PageFactory.InitElements(DriverContext.driver, this);
        }

        private string rowsCPTgrid= "//table[contains(@id,'NecessityCPT1')]//tr[@class='PanelDetail']";
        private string colCPTgrid = "//table[contains(@id,'NecessityCPT1')]//tr[@class='PanelTitle tableHeader']//td";


        /// <summary>
        /// Method to get CPT code
        /// </summary>
        /// <returns></returns>
        public List<String> GetR1NessityCPT()
        {
            return util.GetColvalues(rowsCPTgrid, colCPTgrid, "CPT");
        }

    }
}