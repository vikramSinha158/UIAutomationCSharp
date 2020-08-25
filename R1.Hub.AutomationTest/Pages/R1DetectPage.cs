using System;
using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;

namespace R1.Hub.AutomationTest.Pages
{
    public class R1DetectPage : BasePage
    {

        public R1DetectPage(DriverContext driverContext) : base(driverContext)
        {
            PageFactory.InitElements(driverContext.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[@class='subhead']//span[text()='R1 Detect']")]
        private IWebElement r1DetectWorklist;


        public ExtendedPage VerifyR1DetectWorklistDisplay()
        {
            util.IsDisplayed(r1DetectWorklist);
            return new ExtendedPage(_driverContext);
        }

    }
}
