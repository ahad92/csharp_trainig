using NUnit.Framework;

namespace WebaddressbookTests.tests
{
    [TestFixture]
    class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(2);
        }
    }
}
