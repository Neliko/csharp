using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    namespace PageObject
    {
        public class Page
        {
            public IWebDriver _driver;

            public Page(IWebDriver driver)
            {
                this._driver = driver;
                PageFactory.InitElements(_driver, this);
            }
        }
    }

}
