using NUnit.Framework;

namespace WebaddressbookTests.tests
{
    [TestFixture]


    class ContactRemovalTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Contacts.Remove(1);
        }
    }
}
