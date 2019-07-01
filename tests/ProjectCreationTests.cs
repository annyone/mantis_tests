using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        //public static Random rnd = new Random();

        [Test]
        public void ProjectCreationTest()
        {
            List<ProjectData> oldList = ProjectData.GetAllFromDB();

            ProjectData project = new ProjectData((rnd.Next()).ToString(), (rnd.Next()).ToString());
            app.Project.Create(project);
            List<ProjectData> newList = ProjectData.GetAllFromDB();
            oldList.Add(project);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
