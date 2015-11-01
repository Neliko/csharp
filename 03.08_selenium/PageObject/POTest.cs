using NUnit.Framework;
using selenium;

namespace PageObject
{
    [TestFixture]
    class PoTest : TestBase
    {
        [Test]
        public void AuthotizTest()
        {
            var loginPage = new LoginPage(Driver);
            const string login = "s.pushkareva";
            const string password = "Neliko123";
            loginPage.DoLogin(login, password);

            var homePage = new PlanetaPage(Driver);
            Assert.That(homePage.Title, Is.EqualTo("Планета 2ГИС"), string.Format("Пользователь {0} не авторизован", login));
        }

    }
}
