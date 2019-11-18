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
            app.Groups.Remove(1, newData);
        }
    }
}
