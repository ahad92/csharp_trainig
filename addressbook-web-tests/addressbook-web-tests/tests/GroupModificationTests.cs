using NUnit.Framework;

namespace WebaddressbookTests
{
    [TestFixture]
    public class GroupModificationTests: AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("editedName");
            newData.Header = null;
            newData.Footer = null;

            app.Navigator.GoToGroupsPage();
                
            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(newData);
            }
            app.Groups.Modify(0, newData);
        }
    }
}
