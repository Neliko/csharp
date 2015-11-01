using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    class PlanetaPage : Page
    {
        public string Title;

        public PlanetaPage(IWebDriver driver)
            : base(driver)
        {
            Title = _driver.Title;
        }
    }
}
