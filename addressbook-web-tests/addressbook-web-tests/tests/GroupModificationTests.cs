using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebaddressbookTests
{
    [TestFixture]
    public class GroupModificationTests: TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("editedName");
            newData.Header = "editedHeader";
            newData.Footer = "editedFooter";
            app.Groups.Modify(1, newData);
        }
    }
}
