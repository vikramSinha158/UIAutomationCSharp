using OpenQA.Selenium;
using R1.Automation.UI.core.Selenium.Base;
using System;
using System.Collections.Generic;
using System.Text;


namespace R1.Hub.AutomationBase.Base
{
    public static class DriverContext
    {
        //public static IWebDriver Driver;

        public static IWebDriver driver = DriverFactory.Driver;


    }
}
