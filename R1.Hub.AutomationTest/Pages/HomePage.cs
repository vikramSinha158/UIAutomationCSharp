using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using R1.Automation.UI.core.Selenium.Extensions;
using SeleniumExtras.PageObjects;

namespace R1.Hub.AutomationTest.Pages
{
    public class HomePage : BasePage
    {
        private readonly string lnkPatientAccess = "//span[contains(@class,'id52')]//a";

        public HomePage(DriverContext driverContext) : base(driverContext)
        {
            PageFactory.InitElements(driverContext.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@title='Logout']")]
        private IWebElement txtLogout;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'Home')]//span[text()='Home']")]
        private IWebElement lblHome;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'LocationChooser_hypLoc')]")]
        private IWebElement lnkFacilityCode;

        [FindsBy(How = How.XPath, Using = "//Select[contains(@name,'LocationChooser$ddlLocation')]")]
        private IWebElement dropDwnFacilityCode;

        public void ClickLogOut() => txtLogout.Click();

        public void ClickFaciclityCode() => lnkFacilityCode.Click();

        /// <summary>
        /// Method to select facility code
        /// </summary>
        /// <param name="text"></param>
        public void SelectFacilityCode(string text)
        {
            dropDwnFacilityCode.ClickDropDownValuebyContainingText(text);
        }

        /// <summary>
        /// Click on Patient Access link
        /// </summary>
        /// <returns>Return PatientAccessPage</returns>
        public PatientAccessPage ClickPatientAccessTab()
        {
            _driverContext.Driver.FindElement(By.XPath(lnkPatientAccess)).Click();
            return new PatientAccessPage(_driverContext);
        }

        /// <summary>
        /// Home Page Validation method
        /// </summary>        
        public void VerifyHomePageVisible()
        {
            string ss = lblHome.Text;
        }
    }
}