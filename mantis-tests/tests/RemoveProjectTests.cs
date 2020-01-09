using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace mantis_tests
{
    [TestFixture]
    public class RemovalProjectTests : Auth_TestBase
    {
        [Test]
        public void TestRemovalProject()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldList = app.API.GetAllProjects(account);
            if (oldList.Count() < 1)
            {
                ProjectData project = new ProjectData()
                {
                    Name = GenerateRandomString(10),
                };


                app.API.AddProject(account, project);
            }

            oldList = app.API.GetAllProjects(account);

            ProjectData existingProject = oldList[0];

            app.API.RemoveProject(account, existingProject);

            List<ProjectData> newList = app.API.GetAllProjects(account);

            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}