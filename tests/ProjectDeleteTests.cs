using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectDeleteTests : AuthTestBase
    {
        [Test]
        public void ProjectDeleteTest()
        {
            app.Nav.OpenManageProjectPage();
            app.Project.IsExist();
            List<ProjectData> oldList = ProjectData.GetAllFromDB();
            ProjectData forRemove = oldList[0];
            app.Project.Delete(forRemove);
            List<ProjectData> newList = ProjectData.GetAllFromDB();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);

            foreach (ProjectData project in newList)
            {
                Assert.AreNotEqual(project.Id, forRemove.Id);
            }
        }
    }
}
