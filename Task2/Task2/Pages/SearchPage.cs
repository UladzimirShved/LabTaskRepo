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

namespace Task2
{
    public static class SearchPage
    {
        static BaseElement searchResult = new BaseElement(By.XPath("//div[@class = 'wp-feature-articles']"), "Search Result");

        static Logger logger = LogManager.GetCurrentClassLogger();

        public static bool CheckSearch(IWebDriver driver)
        {
            logger.Info("Checking if search has results by checking element with XPath: {0}", searchResult.locator);
            if (searchResult.GetElement(driver) == null)
            {
                logger.Info("No results! Its a bug if data was valid");
                return false;
            }
            logger.Info("Everything is ok with simple search");
            return true;
        }
    }

}
