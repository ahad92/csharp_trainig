using NUnit.Framework;

namespace WebaddressbookTests

{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void TheGroupRemoveTest()
        {
            app.Groups.Remove(2);
        }
    }
}
