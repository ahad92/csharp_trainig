﻿using NUnit.Framework;
using System.Collections.Generic;

namespace WebaddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Edited_Name", "EditedLastName")
            {
                MiddleName = "EditedMiddleName",
                Nickname = null,
                Email = "Edited_testemail@mailbox213.com"
            };

            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(newContactData);
            }
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContactData = oldContacts[0];


            //            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(oldContactData, newContactData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = newContactData.FirstName;
            oldContacts[0].LastName = newContactData.LastName;
            oldContacts.Sort();
            newContacts.Sort();

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual(newContactData.FirstName, contact.FirstName);
                    Assert.AreEqual(newContactData.LastName, contact.LastName);
                }
            }
        }
    }
}