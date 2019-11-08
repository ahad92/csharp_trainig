using NUnit.Framework;


namespace WebaddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : TestBase
    {
        [Test]
        public void ContactCreationTests()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitContactCreation();
            ContactData contact = new ContactData("Myname", "MyMiddlename");
            contact.LastName = "MyLastName";
            contact.Nickname = "MyNickname";
            contact.Email = "testemail@mailbox213.com";
            FillContactForm(contact);
            SubmitContactCreation();
            Logout();

        }
    }
}