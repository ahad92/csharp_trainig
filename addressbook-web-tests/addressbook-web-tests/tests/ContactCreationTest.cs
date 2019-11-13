using NUnit.Framework;

namespace WebaddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : TestBase
    {
        [Test]
        public void ContactCreationTests()
        {
            ContactData contact = new ContactData("Myname", "MyMiddlename");
            contact.LastName = "MyLastName";
            contact.Nickname = "MyNickname";
            contact.Email = "testemail@mailbox213.com";
            
            app.ContactHelper
                .InitContactCreation()
                .FillContactForm(contact)
                .SubmitContactCreation();
        }
    }
}