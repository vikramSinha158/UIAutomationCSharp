using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace R1.Hub.AutomationTest.Pages
{
    public class AccountPage : BasePage
    {
        public AccountPage(DriverContext driverContext) : base(driverContext)
        {
            PageFactory.InitElements(driverContext.Driver, this);
        }



        [FindsBy(How = How.XPath, Using = "//a[text()='Coverage']")]
        private IWebElement coverageTab;

        [FindsBy(How = How.XPath, Using = "//a[text()='R1 Necessity™']")]
        private IWebElement R1NecessityTab;

        [FindsBy(How = How.XPath, Using = "//a[text()='Services']")]
        private IWebElement serviceTab;

        [FindsBy(How = How.XPath, Using = "//a[text()='Check Out']")]
        private IWebElement btnCheckOut;

        [FindsBy(How = How.XPath, Using = "//a[text()='Redo']")]
        private IWebElement btnRedo;

        [FindsBy(How = How.XPath, Using = "//a[text()='Complete']")]
        private IWebElement btnComplete;

        public CoveragePage ClickOnCoverageTab()
        {
            coverageTab.Click();
            return new CoveragePage(_driverContext);
        }

        /// <summary>
        /// Cheking R1Necessity tab is visible or not
        /// </summary>
        /// <returns></returns>
        public bool IsR1NecessityVisible()
        {
            bool isvisble = false;
            try
            {
                if (R1NecessityTab.Displayed)
                    isvisble = true;
                return isvisble;
            }
            catch (NoSuchElementException e)
            {
                return isvisble;
            }
            
        }

        /// <summary>
        /// click on Service tab
        /// </summary>
        /// <returns>Service page</returns>
        public ServicesPage ClickOnServicesTab()
        {
            serviceTab.Click();
            return new ServicesPage(_driverContext);
        }

        /// <summary>
        /// Click on R1Necessity tab
        /// </summary>
        /// <returns></returns>
        public R1NecessityPage ClickOnR1Necessity()
        {
            R1NecessityTab.Click();
            return new R1NecessityPage(_driverContext);
        }

        /// <summary>
        /// Click on Checkot and Redo button
        /// </summary>
        public void ClickCheckOutAndRedo()
        {
            try
            {
                if (btnCheckOut.Displayed == true)
                    btnCheckOut.Click();
              
            }
            catch (NoSuchElementException e)
            { }
            try {
                if (btnRedo.Displayed == true)
                    btnRedo.Click();
            }
            catch (NoSuchElementException e)
            { }


        }

        /// <summary>
        /// Click on Complete button
        /// </summary>
        public void ClickComplete()
        {
            btnComplete.Click();
        }

    }
}
