using System;
using HttpRequestHelper;
using Newtonsoft.Json;
using NUnit.Framework;

namespace at
{
    class JsonObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    [TestFixture]
    class Program
    {
        [Test]
        public void ContactsServiceTest()
        {
            var request = new GetRequest(
            "http://10.54.19.176/wsc-test/ContactsService/service.asmx/AddContact?name=Test&phone=1111");
            var responseAddContact = request.GetResponse().StringData();
            var testObj = Newtonsoft.Json.Linq.JObject.Parse(responseAddContact);

            if (testObj.GetValue("responseCode").ToString() != "200")
            {
                throw new ArgumentException("Error");
            }

            var requestGetContacts = new GetRequest("http://10.54.19.176/wsc-test/ContactsService/service.asmx/GetContacts?count=" + 200);
            var responseGetContacts = requestGetContacts.GetResponse().StringData();

            var testObj2 = Newtonsoft.Json.Linq.JObject.Parse(responseGetContacts);

            if (testObj2.GetValue("responseCode").ToString() != "200")
            {
                throw new ArgumentException("Error");
            }

            var parseJsonGetContact = JsonConvert.DeserializeObject(testObj2.ToString());

            var contact = testObj2.GetValue("contacts").Last;
            var objArr = JsonConvert.DeserializeObject<JsonObject>(testObj2["contacts"].Last.ToString());

            Assert.AreEqual("Test", objArr.Name);
            Assert.AreEqual("1111", objArr.Phone);
        }
        static void Main(string[] args)
        {

        }
    }
}
