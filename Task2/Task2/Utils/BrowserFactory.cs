using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace Task2
{
    public class BrowserFactory
    {
        public static IWebDriver GetBrowser(String browser)
        {
            IWebDriver driver = null;

            switch (browser)
            {
                case "firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                    }
                    break;

                case "chrome":

                    if (driver == null)
                    {
                        driver = new ChromeDriver();
                    }
                    break;

                case "remote":                    
                    DesiredCapabilities desiredCap = DesiredCapabilities.Chrome();
                    desiredCap.SetCapability("browserstack.user", "uladzimir5");
                    desiredCap.SetCapability("browserstack.key", "RSQy6UiFJ5iEUDg2EosK");

                    driver = new RemoteWebDriver(
                      new Uri("http://hub-cloud.browserstack.com/wd/hub/"), desiredCap
                    );
                    break;
            }
            return driver;
        }
    }
}
