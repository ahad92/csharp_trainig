using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebaddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemoveTest()
        {
            GroupData group = new GroupData("editedName");
            group.Header = "editedHeaderDel";
            group.Footer = "editedFooterDEL";

            app.Navigator.GoToGroupsPage();
            //        List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(group);
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);


            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            //  List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();
            if (oldGroups.Count > 0)
                oldGroups.RemoveAt(0);

            foreach (GroupData group1 in newGroups)
            {
                Assert.AreNotEqual(group1.Id, toBeRemoved.Id);
            }
        }
    }
}
