using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    class ProjectCreationTests : AuthTestBase
    {

        [Test]
        public void ProjectCreationTest()
        {
            List<ProjectData> oldList = new List<ProjectData>();
            app.Project.Create();
//            return;
        }
    }
}
