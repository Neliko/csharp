using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Action
{
    class LoginAction
    {
        private readonly IWebDriver _driver;
        public LoginAction(IWebDriver driver)
        {
            _driver = driver;
        }
        public PlanetaPage DoLogin(string login, string password)
 {
          var page = new LoginPage(_driver);
          page.Open();
          page.LoginField.SendKeys(login);
          page.PasswordField.SendKeys(password);

          return new PlanetaPage(_driver);
 }

    }
}
