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
    class LoginPage : Page
    {

        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement LoginField;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordField;

        [FindsBy(How = How.ClassName, Using = "input_submit")]
        public IWebElement SubmitButton;

        public void Open()
        {
            _driver.Navigate().GoToUrl("https://planeta.2gis.ru");
        }

    }
}
