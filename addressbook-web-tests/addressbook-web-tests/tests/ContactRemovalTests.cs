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
            ContactData contact = new ContactData("MynameBeforeDeleting", "MyLastnameBeforeDeleting");
            List<ContactData> oldContacts = app.Contacts.GetContactList();


            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(contact);
            }
            app.Contacts.Remove(0);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData newContact in newContacts)
            {
                Assert.AreNotEqual(newContact.Id, toBeRemoved.Id);
            }
        }
    }
}
