using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebaddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            app.Contacts.GetContactInformationFromTable();
            app.Contacts.GetContactInformationFromForm();
        }
    }
}


