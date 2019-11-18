﻿using NUnit.Framework;

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
            app.Contacts.Create(contact);
        }
    }
}