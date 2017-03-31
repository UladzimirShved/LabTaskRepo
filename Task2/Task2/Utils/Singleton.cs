using System.IO;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Text;
using System.Threading.Tasks;

/*
 * не используется, но может пригодиться
 */
namespace Task2
{
    public class Singleton
    {
        private static IWebDriver instance = null;
        protected Singleton()
        {
        }
        public static IWebDriver GetInstance()
        {
            string browser = TestData.browser;
            if (instance == null)
            {
                if (instance == null)
                {
                    instance = BrowserFactory.GetBrowser(browser);
                }
            }

            return instance;
        }
    }
}
