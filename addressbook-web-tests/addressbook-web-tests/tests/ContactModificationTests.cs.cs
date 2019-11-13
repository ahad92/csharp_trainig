using NUnit.Framework;


namespace WebaddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Myname", "MyMiddlename");
            newContactData.LastName = "MyLastName";
            newContactData.Nickname = "MyNickname";
            newContactData.Email = "testemail@mailbox213.com";

            app.Contacts.Modify(1, newContactData);
        }
    }
}