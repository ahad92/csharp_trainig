using NUnit.Framework;


namespace WebaddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {

            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";

            app.Groups.Create(group);
        }
        public void EmptyGroupCreationTest()

        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group);
         }
    }
}
    

