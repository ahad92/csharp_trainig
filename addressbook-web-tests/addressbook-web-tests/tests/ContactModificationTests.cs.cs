using NUnit.Framework;

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

            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(newContactData);
            }

            app.Contacts.Modify(1,1,newContactData);
        }
    }
}