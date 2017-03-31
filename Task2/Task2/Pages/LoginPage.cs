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
    public static class LoginPage
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        static BaseElement loginBar = new BaseElement(By.XPath("//input[@placeholder='Username or Email']"), "Login Bar");
        static BaseElement passwordBar = new BaseElement(By.XPath("//input[@placeholder='Password']"), "Password Bar");
        static BaseElement loginButton = new BaseElement(By.XPath("//input[@value='Login']"), "Login Button on Login Page");
        public static void Login(IWebDriver driver)
        {
            logger.Info("Input login info into {0}", loginBar.name);
            loginBar.FillLabel(TestData.login, driver);
            logger.Info("Input password info into {0}", passwordBar.name);
            passwordBar.FillLabel(TestData.password, driver);
            loginButton.MyClick(driver);
        }
    }
}
