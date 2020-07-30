using OpenQA.Selenium;
using R1.Automation.UI.core.Selenium.Base;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Remote;


namespace R1.Hub.AutomationBase.Base
{
    public class DriverContext
    {
        public RemoteWebDriver Driver { get; set; }
        public BasePage CurrentPage { get; set; }
    }
}
