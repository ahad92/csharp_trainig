using NUnit.Framework;

namespace WebaddressbookTests.tests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("MynameBeforeDeleting", "MyMiddlenameBeforeDeleting");
            app.Contacts.Remove(1, contact);
        }
    }
}
