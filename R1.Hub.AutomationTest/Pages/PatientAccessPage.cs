using OpenQA.Selenium;
using R1.Automation.UI.core.Selenium.Extensions;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;
using System;

namespace R1.Hub.AutomationTest.Pages
{
    public class PatientAccessPage:BasePage
    {
        private string conversionFollow = "//a/span[text()='Conversion Followup']";

        public PatientAccessPage(DriverContext driverContext) : base(driverContext)
        {
            PageFactory.InitElements(driverContext.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'Pre-Registration')]")]
        private IWebElement lnkPreRegistration;

        [FindsBy(How = How.XPath, Using = "//a/span[text()='Conversion Followup']")]
        private IWebElement lnkConversionFollowup;


        [FindsBy(How = How.XPath, Using = "//a/span[text()='R1 Detect']")]
        private IWebElement lnkR1DetectWorkList;

        /// <summary>
        /// Click on pre registration link
        /// </summary>
        /// <returns></returns>
        public PreRegistrationPage ClickOnPreRegistration()
        {
            lnkPreRegistration.Click();
            return new PreRegistrationPage(_driverContext);
        }

        /// <summary>
        /// Click On Conversion FollowUp
        /// </summary>
        /// <returns>Conversion Followup Page</returns>
        public ConversionFollowupPage ClickOnConversionFollowUp()
        {
            _driverContext.Driver.ScrollInView(lnkConversionFollowup);
            _driverContext.Driver.ClickOnElement(lnkConversionFollowup);
            return new ConversionFollowupPage(_driverContext);
        }

        public R1DetectPage ClickOnR1DetectWorkList()
        {          
            ClickOnWorklist(lnkR1DetectWorkList);
            return new R1DetectPage(_driverContext);
        }

        private void ClickOnWorklist(IWebElement elemnent)
        {
            _driverContext.Driver.ScrollInView(elemnent);
            _driverContext.Driver.ClickOnElement(elemnent);
        }

      

        //public void ThenIClickButton(string buttonName)
        //{
        //    if (buttonName == "login")
        //        _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<LoginPage>().ClickLoginButton();
        //    else if (buttonName == "createnew")
        //        _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<EmployeeListPage>().ClickCreateNew();
        //    else if (buttonName == "create")
        //        _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<CreateEmployeePage>().ClickCreateButton();
        //}
    }
}
