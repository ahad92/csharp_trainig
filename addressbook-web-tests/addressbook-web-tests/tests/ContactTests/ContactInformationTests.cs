using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebaddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable =  app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm =  app.Contacts.GetContactInformationFromForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address,fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones,fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails,fromForm.AllEmails);
            Assert.AreEqual(fromTable.HomePage,fromForm.HomePage);
        }

        public void TestContactDatiledInformation()
        {
            string fromTable = app.Contacts.GetContactInformationFromDetails(0);
            string fromForm = app.Contacts.GetAllContactInformationFromForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);

        }
    }
}


