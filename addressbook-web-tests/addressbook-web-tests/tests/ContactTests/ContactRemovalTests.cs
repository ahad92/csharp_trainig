using NUnit.Framework;
using System.Collections.Generic;

namespace WebaddressbookTests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("MynameBeforeDeleting", "MyLastnameBeforeDeleting");

  //          List<ContactData> oldContacts = app.Contacts.GetContactList();

            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeRemoved = oldContacts[0];
            app.Contacts.Remove(toBeRemoved);
            //List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
                        List<ContactData> newContacts = ContactData.GetAll();

            if (oldContacts.Count > 0)
                oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData newContact in newContacts)
            {
                Assert.AreNotEqual(newContact.Id, toBeRemoved.Id);
            }
        }
    }
}
