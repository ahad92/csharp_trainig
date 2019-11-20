using NUnit.Framework;

namespace WebaddressbookTests

{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void TheGroupRemoveTest()
        {
            GroupData newData = new GroupData("editedName");

            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(newData);
            }
            app.Groups.Remove(1);
        }
    }
}
