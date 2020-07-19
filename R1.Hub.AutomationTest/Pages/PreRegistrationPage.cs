using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xunit;
using SeleniumExtras.PageObjects;

namespace R1.Hub.AutomationTest.Pages
{
    public class PreRegistrationPage:BasePage
    {
        private static int minRowsInWorkList = 2;
        public PreRegistrationPage(DriverContext driverContext) : base(driverContext)
        {
            PageFactory.InitElements(driverContext.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//table[@class='worklistTable']//tbody/tr[@valign='middle']")]
        private IList<IWebElement> totalAccontRows;

        [FindsBy(How = How.XPath, Using = "//table[@class='worklistTable']//tbody/tr[@valign='middle'][7]//td[@class='rowNumber']")]
        private IWebElement firstAccount;

 

        /// <summary>
        /// click on account
        /// </summary>
        /// <returns></returns>
        public AccountPage ClickOnAccount()
        {

            try
            {
               
                if(totalAccontRows.Count > minRowsInWorkList)
                {
                    firstAccount.Click();

                    return new AccountPage(_driverContext);
                }
                else {
                    Assert.True(false, "No row found for account");
                }
            }
            catch (NoSuchElementException e)
            {
                Assert.True(false, "No Record found to click " + e.Message);
                return null;
            }
            return null;

        }        
    }
             
}
