using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    public class LoginPage : Page
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement LoginField;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordField;

        [FindsBy(How = How.ClassName, Using = "input_submit")]
        public IWebElement SubmitButton;


        public void DoLogin(string login, string password)
        {
            LoginField.SendKeys(login);
            PasswordField.SendKeys(password);

            SubmitButton.Click();
        }
    }
}
