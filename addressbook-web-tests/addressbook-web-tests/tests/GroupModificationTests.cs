using NUnit.Framework;

namespace WebaddressbookTests
{
    [TestFixture]
    public class GroupModificationTests: TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("editedName");
            newData.Header = "editedHeader";
            newData.Footer = "editedFooter";
            app.Groups.Modify(2, newData);
        }
    }
}
