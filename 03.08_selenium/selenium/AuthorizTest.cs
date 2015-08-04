using NUnit.Framework;
using OpenQA.Selenium;

namespace selenium
{
    [TestFixture]
    public class AuthorizTest : TestBase
    {
        [Test]
        public void AuthWithTestUserData()
        {
            var login = Driver.FindElement(By.Id("login"));
            login.SendKeys("s.pushkareva");

            var password = Driver.FindElement(By.Id("password"));
            password.SendKeys("Neliko123");

            var button = Driver.FindElement(By.ClassName("input_submit"));
            button.Click();

            var title = Driver.Title;

            Assert.AreEqual("Планета 2ГИС", title, "Заголовок вкладки отличается от ожидаемого результата");
        }

    }
}
