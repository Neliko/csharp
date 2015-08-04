using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace PageObject
{
    public class TestBase
    {
        protected IWebDriver Driver { get; set; }

        [TestFixtureSetUp]
        public void BeforeClass()
        {
            Driver = new FirefoxDriver();
            Driver.Navigate().GoToUrl("https://planeta.2gis.ru");
        }

        [TestFixtureTearDown]
        public void AfterClass()
        {
            Driver.Quit();
        }
    }
}
