using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Action
{
    internal class PlanetaPage : Page
    {
        public string Title;
        public PlanetaPage(IWebDriver driver) :  base(driver)
        {
            Title = _driver.Title;
        }
    }
}
