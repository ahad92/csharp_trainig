using NUnit.Framework;
using System.Collections.Generic;

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
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(newData);
            }
            app.Groups.Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData in newGroups)
            {
                Assert.AreNotEqual(group.Id, oldGroups[0].Id);
            }
        }
    }
}
