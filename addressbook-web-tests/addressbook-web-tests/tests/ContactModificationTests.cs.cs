using NUnit.Framework;


namespace WebaddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Edited_Name", " Edited_MyMiddlename");
            newContactData.LastName = "Edited_LastName";
            newContactData.Nickname = "Edited_MyNickname";
            newContactData.Email = "Edited_testemail@mailbox213.com";

            app.Contacts.Modify(2,2,newContactData);
        }
    }
}