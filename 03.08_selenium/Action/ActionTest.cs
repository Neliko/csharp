using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Action
{
    [TestFixture]
    class ActionTest : TestBase
    {
        [Test]
        public void AuthorizActionTest()
        {
            const string login = "s.pushkareva";
            const string password = "Neliko123";
            var homePage = new LoginAction(Driver).DoLogin(login, password);
            Assert.That(homePage.Title, Is.EqualTo("Планета 2ГИС"), string.Format("Пользователь {0} не авторизован", login));
        }

    }
}
