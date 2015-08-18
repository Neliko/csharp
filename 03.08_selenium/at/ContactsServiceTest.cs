using HttpRequestHelper;
using Newtonsoft.Json;
using NUnit.Framework;

namespace at
{

    [TestFixture]
    public class ContactsServiceTest
    {
        [Test]
        public void AddContactTest()
        {
            var request = new GetRequest(
                "http://10.54.19.176/wsc-test/ContactsService/service.asmx/AddContact?name=Test&phone=1111");
            var responseAddContact = request.GetResponse().StringData();
            var testObj = Newtonsoft.Json.Linq.JObject.Parse(responseAddContact);

            Assert.AreEqual("200", testObj.GetValue("responseCode").ToString(), "Возникла ошибка при обращении к сервису");
        }

        [Test]
        public void GetLastContactTest()
        {
            var requestGetContacts =
              new GetRequest("http://10.54.19.176/wsc-test/ContactsService/service.asmx/GetContacts?count=" + 200);
            var responseGetContacts = requestGetContacts.GetResponse().StringData();

            var testObj = Newtonsoft.Json.Linq.JObject.Parse(responseGetContacts);

            Assert.AreEqual("200", testObj.GetValue("responseCode").ToString(), "Возникла ошибка при обращении к сервису");

            var contact = testObj.GetValue("contacts").Last;
            var objArr = JsonConvert.DeserializeObject<JsonObject>(testObj["contacts"].Last.ToString());

            Assert.AreEqual("Test", objArr.Name);
            Assert.AreEqual("1111", objArr.Phone); 
        }

    }
}
