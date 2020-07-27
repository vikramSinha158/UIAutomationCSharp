using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace R1.Hub.AutomationTest.Pages
{
    public class R1NecessityPage:BasePage
    {

        private string rowsCPTgrid = "//table[contains(@id,'NecessityCPT1')]//tr[@class='PanelDetail']";
        private string colCPTgrid = "//table[contains(@id,'NecessityCPT1')]//tr[@class='PanelTitle tableHeader']//td";

        public R1NecessityPage(DriverContext driverContext) : base(driverContext)
        {
            PageFactory.InitElements(driverContext.Driver, this);
        }


        /// <summary>
        /// Method to get CPT code
        /// </summary>
        /// <returns>Get R1Nessity CPT code in listr</returns>
        public List<String> GetR1NessityCPT()
        {
            return util.GetColvalues(_driverContext.Driver,rowsCPTgrid, colCPTgrid, "CPT");
        }

    }
}
