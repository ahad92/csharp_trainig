using NUnit.Framework;
using System.Collections.Generic;

namespace WebaddressbookTests
{
    [TestFixture]
    public class GroupModificationTests: GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("editedName");
            newData.Header = "editedHeader";
            newData.Footer = "editedFooter";

            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(newData);
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldData, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldData.Name = newData.Name;

//          List<GroupData> newGroups = app.Groups.GetGroupList();
//          oldGroups[0].Name= newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
