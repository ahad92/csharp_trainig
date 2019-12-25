using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WebaddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase

    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(10))
                {
                    Header = GenerateRandomString(10),
                    Footer = GenerateRandomString(10)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromXMLFile()
        {
            return(List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));        
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newContacts = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldGroups, newContacts);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("bad_name");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    } 
}
    

