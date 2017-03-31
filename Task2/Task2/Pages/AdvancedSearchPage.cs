using System.IO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Text;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium.Support.UI;

namespace Task2.Pages
{
    public static class AdvancedSearchPage
    {
        static BaseElement tempLabel = new BaseElement();
        static BaseElement tempScope = new BaseElement();
        static BaseElement advancedSearchButton = new BaseElement(By.XPath("//input[@value = 'Search']"), "Search Button");
        static BaseElement advancedSearchResult = new BaseElement(By.XPath("//div[. = '0 results']"), "Advanced Search Results");
        
        static BaseElement multiJourn = new BaseElement(By.XPath("//div[@class = 'journalNamesDiv']"), "Check Boxes");
        static List<IWebElement> checkBoxes = new List<IWebElement>();//multiJourn.getElement().FindElements();
        static Dictionary<string, string> advancedSearchData = GetDataForLabels();
        static string tmpScopeXPath;
        static string tmpKeyXPath;

        static Logger logger = LogManager.GetCurrentClassLogger();

        public static Dictionary<string, string> GetDataForLabels()
        {
            Dictionary<string, string> tmpDict = new Dictionary<string, string>();
            string[] keyWordsFromTestData = TestData.advancedKeywords.Split(new char[] { ';' });//, StringSplitOptions.RemoveEmptyEntries);
            string[] scopeValuesFromTestData = TestData.advancedSelects.Split(new char[] { ';' });//, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < keyWordsFromTestData.Count(); i++)
            {
                tmpDict.Add(scopeValuesFromTestData[i], keyWordsFromTestData[i]);
            }
            return tmpDict;
        }

        public static void FillAdvancedSearch(IWebDriver driver)
        {
            for (int i = 0; i < advancedSearchData.Count; i++)            
            {
                tmpScopeXPath = string.Format("//select[@id = 'dplScope_{0}']", i+1);                
                tempScope.locator = By.XPath(tmpScopeXPath);
                tempScope.name = advancedSearchData.ElementAt(i).Key;
                SelectElement select = new SelectElement(tempScope.GetElement(driver));
                logger.Info("Selecting {0} in {1} scope, its Locator: {2}", tempScope.name, i+1, tempScope.locator);
                select.SelectByValue(tempScope.name);

                tmpKeyXPath = string.Format("//input[@id = 'keywords_input_{0}']", i+1);
                tempLabel.locator = By.XPath(tmpKeyXPath);               
                tempLabel.FillLabel(advancedSearchData.ElementAt(i).Value, driver);
            }
            if (multiJourn.GetElement(driver) != null)
            {
                checkBoxes = /*Singleton.getInstance()*/driver.FindElements(multiJourn.locator).ToList();
                foreach (var checkbox in checkBoxes)
                {
                    if (!checkbox.Selected)
                    {
                        logger.Info("Selecting Check Box");
                        checkbox.Click();
                    }
                }
            }
        }

        public static void MakeSearch(IWebDriver driver)
        {
            FillAdvancedSearch(driver);
            advancedSearchButton.MyClick(driver);
        }

        public static bool CheckSearch(IWebDriver driver)
        {
            logger.Info("Checking if search has results by checking element with XPath: {0}", advancedSearchResult.locator);
            if (advancedSearchResult.GetElement(driver) == null)
            {
                logger.Info("No results! Its a bug if data was valid");
                return false;
            }
            logger.Info("Everything is ok with advanced search");
            return true;
        }

        
    }
}
