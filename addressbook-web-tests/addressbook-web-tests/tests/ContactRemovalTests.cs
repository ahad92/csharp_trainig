﻿using NUnit.Framework;

namespace WebaddressbookTests.tests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(2);
        }
    }
}
