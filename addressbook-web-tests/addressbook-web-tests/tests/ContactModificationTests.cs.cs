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

            List<ContactData> oldContact = app.Contacts.GetContactList();

            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(newContactData);
            }
            app.Contacts.Modify(1, 1, newContactData);

            List<ContactData> newGroups = app.Contacts.GetContactList();
            oldContact[0].FirstName = newContactData.FirstName;
            oldContact[0].LastName = newContactData.LastName;
            oldContact.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldContact, newGroups);


        }
    }
}