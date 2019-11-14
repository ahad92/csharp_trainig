using NUnit.Framework;

namespace WebaddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TheGroupRemoveTest()
        {
            app.Groups.Remove(2);
        }
    }
}
