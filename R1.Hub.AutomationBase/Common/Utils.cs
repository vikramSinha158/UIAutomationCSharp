﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using System.Data;
using R1.Automation.Database.core.Base;
using R1.Automation.UI.core.Commons;
using OpenQA.Selenium.Remote;

namespace R1.Hub.AutomationBase.Common
{
    public class Utils
    {

		private DataAccess dataAccess  = new DataAccess();
		private CommonUtility comUtil = new CommonUtility();
	

		/// <summary>
		/// Check display of element
		/// </summary>
		/// <param name="element"></param>
		public void IsDisplayed(IWebElement element)
		{
			bool display = false;
			try
			{
				if (element.Displayed)
					display = true;
			}
			catch (NoSuchElementException)
			{
				Assert.True(display, "Element not visible");
			}
			
		
		}

		/// <summary>
		/// check the display of list of element
		/// </summary>
		/// <param name="elements"></param>
		private  void isDisplayListItem(IList<IWebElement> elements)
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

		/// <summary>
		/// get the column values in list
		/// </summary>
		/// <param name="rowLocator"></param>
		/// <param name="colLocator"></param>
		/// <param name="colName"></param>
		/// <returns>Return the values of coulmn in list</returns>
		public List<String> GetColvalues(RemoteWebDriver driver, String rowLocator, String colLocator, String colName)
		{
			List<String> colValues = new List<String>();
			int rowSize = driver.FindElements(By.XPath(rowLocator)).Count;
			int colSize = driver.FindElements(By.XPath(colLocator)).Count;
			for (int col = 1; col <= colSize; col++)
			{
				String colLocator1 = colLocator + "[" + col + "]";
				try
				{
					String colname = driver.FindElement(By.XPath(colLocator1)).Text;
					if (colname.Equals(colName, StringComparison.OrdinalIgnoreCase))
					{
						for (int row = 1; row <= rowSize; row++)
						{
							//WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
							//wait.Until(_driver => rowLocator + "[" + row + "]/td[" + col + "]");
							//new R1ContactCommons(_driver, _settings).highLightSteps(_driver.FindElement(By.XPath(rowLocator + "[" + row + "]/td[" + col + "]")));
							colValues.Add(driver.FindElement(By.XPath(rowLocator + "[" + row + "]/td[" + col + "]")).Text);
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


		/// <summary>
		/// check eqaulty of two list
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="otherlist"></param>
		/// <returns>Return the bool value whether two list are equal or not</returns>
		public bool CompareList<T>(List<T> list, List<T> otherlist) where T : IEquatable<T>
		{
			if (list.Except(otherlist).Any())
				return false;
			if (otherlist.Except(list).Any())
				return false;
			return true;
		}


		/// <summary>
		/// check contain of second list in first list
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list1"></param>
		/// <param name="otherlist"></param>
		/// <returns>return the bool to check contain of second list in first list</returns>
		public bool CheckContainList<T>(List<T> list1, List<T> otherlist) where T : IEquatable<T>
		{
			if (list1.Intersect(otherlist).Any())
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// seperate the string on the basis of pipe
		/// </summary>
		/// <param name="input"></param>
		/// <returns>Retur the lsit of string  from pipeine string</returns>
		public List<String> GetTestData(String input)

		{
			List<String> dataList = new List<String>();

			String[] dataText = input.Split("|");
			foreach (String txt in dataText)
			{
				dataList.Add(txt);
			}

			return dataList;
		}

		/// <summary>
		/// Compare two integer number
		/// </summary>
		/// <param name="int1"></param>
		/// <param name="int2"></param>
		/// <returns>Return bool after comperison two integer</returns>
		public bool CompareInteger(int int1, int int2)
		{
			if (int1 == int2)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Move Horizontal
		/// </summary>
		public void ScrollHorizontal(RemoteWebDriver driver)
		{
			((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(3000,0)", "");
		}


		/// <summary>
		/// Get total row in DB
		/// </summary>
		/// <param name="dbConnection"></param>
		/// <param name="queryKey"></param>
		/// <returns>Return total number of row in table </returns>
		public int GetTotalRowCountTable(IDbConnection dbConnection, string queryKey)
		{
			//int totalRow;
			string query = comUtil.GetQueryData(queryKey).Trim();
			DataTable dataTable = dataAccess.SelectExecuteQuery(dbConnection, query);
			return dataTable.Rows.Count;
		}

		/// <summary>
		/// Get webelemnet in list
		/// </summary>
		/// <param name="elements"></param>
		/// <returns>Retur the lsit of string  from webElemnet list</returns>
		public List<string> GetElementList(IList<IWebElement>  elements)
		{
			List<String> elementList = new List<String>();

			for (int i = 0; i < elements.Count; i++)
			{
				if (!(string.IsNullOrEmpty(elements[i].Text)))
					elementList.Add(elements[i].Text);
			}

			return elementList;
		}

	}
}
