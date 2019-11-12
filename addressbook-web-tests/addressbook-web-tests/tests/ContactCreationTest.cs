using NUnit.Framework;

namespace WebaddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : TestBase
    {
        [Test]
        public void ContactCreationTests()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.GroupHelper.InitContactCreation();
            ContactData contact = new ContactData("Myname", "MyMiddlename");
            contact.LastName = "MyLastName";
            contact.Nickname = "MyNickname";
            contact.Email = "testemail@mailbox213.com";
            app.GroupHelper.FillContactForm(contact);
            app.GroupHelper.SubmitContactCreation();
            app.Navigator.Logout();
        }
    }
}