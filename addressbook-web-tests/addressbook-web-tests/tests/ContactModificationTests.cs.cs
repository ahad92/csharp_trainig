using NUnit.Framework;
using System.Collections.Generic;

namespace WebaddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Edited_Name", " Edited_MyMiddlename");
            newContactData.LastName = "EditedLastName";
            newContactData.Nickname = null ;
            newContactData.Email = "Edited_testemail@mailbox213.com";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(newContactData);
            }
            app.Contacts.Modify(1, 1, newContactData);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactList();
            newContacts[0].FirstName = newContactData.FirstName;
            newContacts[0].LastName = newContactData.LastName;
            newContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}