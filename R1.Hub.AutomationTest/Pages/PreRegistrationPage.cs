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
        public PreRegistrationPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            PageFactory.InitElements(DriverContext.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//table[@class='worklistTable']//tbody/tr[@valign='middle']")]
        private IList<IWebElement> totalAccontRows;

        [FindsBy(How = How.XPath, Using = "//table[@class='worklistTable']//tbody/tr[@valign='middle'][1]//td[@class='rowNumber']")]
        private IWebElement firstAccount;

 

        public AccountPage ClickOnAccount()
        {

            try
            {
               
                if(totalAccontRows.Count > minRowsInWorkList)
                {
                    firstAccount.Click();

                    return new AccountPage(_scenarioContext);
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

        }        }
             
}
