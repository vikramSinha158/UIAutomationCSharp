using OpenQA.Selenium;
using R1.Hub.AutomationBase.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace R1.Hub.AutomationTest.Utility
{
    public class CommonLib
	{

		private static void isDisplayedMethod(IWebElement element)
		{
			Assert.True(element.Displayed);

		}

		/* check the display of list of element */
		private static void isDisplayListItem(IList<IWebElement> elements)
		{
			bool itemDispay = false;

			for (int i = 0; i < elements.Count; i++)
			{

				if (elements[i].Displayed)
				{
					itemDispay = true;
				}
				else
				{
					itemDispay = false;
					Assert.True(itemDispay);
				}
			}
		}

		public List<String> GetColvalues(String rowLocator, String colLocator, String colName)
		{
			List<String> colValues = new List<String>();
			int rowSize = DriverContext.driver.FindElements(By.XPath(rowLocator)).Count;
			int colSize = DriverContext.driver.FindElements(By.XPath(colLocator)).Count;
			for (int col = 1; col <= colSize; col++)
			{
				String colLocator1 = colLocator + "[" + col + "]";
				try
				{
					String colname = DriverContext.driver.FindElement(By.XPath(colLocator1)).Text;
					if (colname.Equals(colName, StringComparison.OrdinalIgnoreCase))
					{
						for (int row = 1; row <= rowSize; row++)
						{
							//WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
							//wait.Until(_driver => rowLocator + "[" + row + "]/td[" + col + "]");
							//new R1ContactCommons(_driver, _settings).highLightSteps(_driver.FindElement(By.XPath(rowLocator + "[" + row + "]/td[" + col + "]")));
							colValues.Add(DriverContext.driver.FindElement(By.XPath(rowLocator + "[" + row + "]/td[" + col + "]")).Text);
						}
						break;
					}
				}
				catch (NoSuchElementException e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return colValues;
		}

		public bool CompareList<T>(List<T> list, List<T> otherlist) where T : IEquatable<T>
		{
			if (list.Except(otherlist).Any())
				return false;
			if (otherlist.Except(list).Any())
				return false;
			return true;
		}
	}
}
