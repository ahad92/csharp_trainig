using NUnit.Framework;
using System.Collections.Generic;

namespace WebaddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : AuthTestBase
    {
        [Test]
        public void ContactCreationTests()
        {
            ContactData contact = new ContactData("Myname", "MyLastName");
            contact.Nickname = "MyNickname";
            contact.Email = "testemail@mailbox213.com";
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}