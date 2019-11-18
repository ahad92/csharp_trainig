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
            app.Groups.Modify(2, newData);
        }
    }
}
