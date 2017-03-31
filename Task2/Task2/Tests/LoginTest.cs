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
using Task2.Pages;

namespace Task2
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class LoginTest
    { 
        private static IWebDriver driverForLogin = BrowserFactory.GetBrowser(TestData.browser);
        static JournalPage journPage = new JournalPage();
        static Logger logger = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void SetUpEverything()
        {
            driverForLogin.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driverForLogin.Manage().Window.Maximize();
            driverForLogin.Navigate().GoToUrl(TestData.baseUrl);
        }

        [Test]
        public void TestLogin()
        {           
            journPage.GoToLogin(driverForLogin);
            LoginPage.Login(driverForLogin);
            journPage.LogOut(driverForLogin);
        }

        [OneTimeTearDown]
        public void CleanAll()
        {
            driverForLogin.Quit();
        }
    }
}
