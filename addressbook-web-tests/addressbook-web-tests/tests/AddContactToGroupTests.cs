using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebaddressbookTests
{

    public class AddContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddContactToGroup()
        {
            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(new GroupData("test1"));
            }

            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(new ContactData("Firstname","Lastname"));
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll()[0];

            app.Contacts.AddContactToGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}