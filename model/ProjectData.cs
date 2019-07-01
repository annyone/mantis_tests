using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData
    {
        public ProjectData()
        {
        }

        public string Name { get; set; }
        public string InheritGlobal { get; set; }
        public string View { get; set; }
        public string Description { get; set; }

        public static List<ProjectData> GetAllFromDB()
        {

        }

    }
}
