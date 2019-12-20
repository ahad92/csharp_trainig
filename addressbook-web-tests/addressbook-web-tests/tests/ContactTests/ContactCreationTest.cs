using NUnit.Framework;
using System.Collections.Generic;

namespace WebaddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
              
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]

        public void ContactCreationTests()
        {
            ContactData contact = new ContactData("Myname", "MyLastName")
            {
                Nickname = "MyNickname",
                Email = "1mail@mail.com",
                Email2 = "2mail@mail.com",
                Email3 = "2mail@mail.com",
                Address = "StreetTest",
                HomePage = "MytestHomePage",
                HomePhone = "+111111111",
                MobilePhone = "+22222222",
                WorkPhone = "+33333333",
            };

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts,newContacts);
        }
    }
}