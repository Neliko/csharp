using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace selenium
{
    public class TestBase
    {
        protected IWebDriver Driver { get; set; }

        [TestFixtureSetUp]
        public void BeforeClass()
        {
            Driver = new FirefoxDriver();
            Driver.Navigate().GoToUrl("https://planeta.2gis.ru");
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
        }

        [TestFixtureTearDown]
        public void AfterClass()
        {
            Driver.Quit();
        }

    }
}
