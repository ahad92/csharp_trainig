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

            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(contact);
            }
                
           app.Contacts.Remove(1);
        }
    }
}
