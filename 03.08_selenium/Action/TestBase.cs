using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Action
{
    public class TestBase
    {
        protected IWebDriver Driver { get; set; }

        [TestFixtureSetUp]
        public void BeforeClass()
        {
            Driver = new FirefoxDriver(); 
        }

        [TestFixtureTearDown]
        public void AfterClass()
        {
            Driver.Quit();
        }
    }
}
