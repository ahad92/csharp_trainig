using NUnit.Framework;


namespace WebaddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.GroupHelper.InitGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            app.GroupHelper.FillGroupForm(group);
            app.GroupHelper.SubmitGroupCreation();
            app.GroupHelper.ReturnToGroupsPage();
            app.Navigator.Logout();
        }
    }
}
    

