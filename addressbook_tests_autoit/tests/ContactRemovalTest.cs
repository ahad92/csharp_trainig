using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void TestContactRemoval()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            if (oldContacts.Count == 0)
            {
                app.Contacts.Add(new ContactData() { FirstName = "New Contact" });
                oldContacts = app.Contacts.GetContactList();
            }

            app.Contacts.Delete(0);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}