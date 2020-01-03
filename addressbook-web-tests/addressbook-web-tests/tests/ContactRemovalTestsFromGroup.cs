using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebaddressbookTests
{

    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(new GroupData("test1"));
            }

            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(new ContactData("Firstname", "Lastname"));
            }

            GroupData group = GroupData.GetAll()[0];

            app.Contacts.AddAllContactsToGroup(group);

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll()[0];

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}