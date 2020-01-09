using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddProjectTests : Auth_TestBase
    {
        [Test]
        public void TestAddProject()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldList = app.API.GetAllProjects(account);

            ProjectData newProject = new ProjectData()
            {
                Name = GenerateRandomString(10),
            };

            oldList = app.API.GetAllProjects(account);
            app.API.AddProject(account, newProject);
            List<ProjectData> newList = app.API.GetAllProjects(account);

            oldList.Add(newProject);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}