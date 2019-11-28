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
            ContactData contact = new ContactData("Myname", "MyMiddlename");
            contact.LastName = "MyLastName";
            contact.Nickname = "MyNickname";
            contact.Email = "testemail@mailbox213.com";
            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.Create(contact);

            List<ContactData> newGroups = app.Contacts.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldContact, newGroups);
        }
    }
}