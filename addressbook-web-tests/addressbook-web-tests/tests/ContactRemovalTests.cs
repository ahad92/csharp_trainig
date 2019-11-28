using NUnit.Framework;
using System.Collections.Generic;

namespace WebaddressbookTests.tests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData contact = new ContactData("MynameBeforeDeleting", "MyMiddlenameBeforeDeleting");

            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(contact);
            }
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
