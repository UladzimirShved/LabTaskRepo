//using System.IO;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using System.Text;
//using System.Threading.Tasks;
//using Task2;
//using Task2.Pages;
//using System.Data;
//using NLog;



/*
 * не используется, но может пригодиться
 */

//namespace MsTestProj
//{
//    [TestClass]
//    public class MsTest
//    {
//        JournalPage journPage = new JournalPage();
//        static Logger logger = LogManager.GetCurrentClassLogger();
//        private TestContext testContextInstance;
//        public TestContext TestContext
//        {
//            get { return testContextInstance; }
//            set { testContextInstance = value; }
//        }

//        [Ignore]
//        [TestMethod]
//        [DeploymentItem("MsTestProj\\DataForMS.xml")]
//        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
//        "C:\\Users\\Uladzimir_Shved\\documents\\visual studio 2015\\Projects\\Task2\\MsTestProj\\DataForMS.xml", "Journal", DataAccessMethod.Sequential)]
//        public void MsTestJournals()
//        {
//            Singleton.getInstance().Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            Singleton.getInstance().Manage().Window.Maximize();
//            string journalName = (string)TestContext.DataRow["JournalName"];
//            List<Journals> dataForParams = DataFromFile.MakeParamsData(journalName);
//            journPage.GoToTheJournal(journalName, Singleton.getInstance());
//            journPage.GoToLogin(Singleton.getInstance());
//            LoginPage.Login(Singleton.getInstance());
//            Assert.IsFalse(Singleton.getInstance().Url.Contains("PageNotFoundError"), "There is no journal named " + journalName);
//            journPage.CheckEverythingForExist(dataForParams.Last(), Singleton.getInstance());
//            journPage.LogOut(Singleton.getInstance());
//        }

//        [TestCleanup]
//        public void CleanAll()
//        {
//            Singleton.getInstance().Quit();
//        }

//    }
//}
