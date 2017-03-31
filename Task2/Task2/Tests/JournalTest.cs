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
using Task2.Utils;

namespace Task2
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class JournalTest
    {
        private static IWebDriver driverForJournals = BrowserFactory.GetBrowser(TestData.browser);
        static JournalPage journPage = new JournalPage();
        static AssertsAccumulator accumulator = new AssertsAccumulator();
        static Logger logger = LogManager.GetCurrentClassLogger();
        //static DeserealisedJournals dj = new DeserealisedJournals();

        static List<Journal> dataForParams = DeserealiseJournals.DeserealiseXml();//.AllJournals;//.JournName;//DataFromFile.MakeParamsData(dj.Deserealise());//TestData.journal);

        [OneTimeSetUp]
        public void SetUpEverything()
        {
            driverForJournals.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driverForJournals.Manage().Window.Maximize();
        }


        //[Ignore("asd")]
        [Test]
        [TestCaseSource("dataForParams")]
        public void TestJournals(Journal journ)
        {
                journPage.GoToTheJournal(journ.JournName, driverForJournals);
                Assert.False(driverForJournals.Url.Contains("PageNotFoundError"), "There is no journal named " + journ.JournName);
                journPage.SearchAndGo(driverForJournals);
                accumulator.Accumulate(() => Assert.True(SearchPage.CheckSearch(driverForJournals), "No results"));
                journPage.GoToTheAdvancedSearch(driverForJournals);
                AdvancedSearchPage.MakeSearch(driverForJournals);
                accumulator.Accumulate(() => Assert.False(AdvancedSearchPage.CheckSearch(driverForJournals), "No results"));
                journPage.GoToTheJournal(journ.JournName, driverForJournals);
                journPage.CheckEverythingForExist(journ, driverForJournals);
                accumulator.Release();                       
        }

        [OneTimeTearDown]
        public void CleanAll()
        {
            driverForJournals.Quit();
        }
    }
}
