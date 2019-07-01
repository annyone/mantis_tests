using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData()
        {
        }

        public ProjectData(string name, string description)
        {
            Name = name;
            Description = description;
        }

        [Column(Name = "id")]
        public string Id { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "inherit_global")]
        public string InheritGlobal { get; set; }

        [Column(Name = "view_state")]
        public string View { get; set; }

        [Column(Name = "description")]
        public string Description { get; set; }

        public static List<ProjectData> GetAllFromDB()
        {
            using (MantisDB db = new MantisDB())
            {
                return (from p in db.Projects select p).ToList();
            }
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }
    }
}
