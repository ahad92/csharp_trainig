using NUnit.Framework;


namespace WebaddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TheGroupRemoveTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.GroupHelper.SelectGroup(1);
            app.GroupHelper.RemoveGroup();
            app.GroupHelper.ReturnToGroupsPage();
            app.Navigator.Logout();
        }
    }
}
