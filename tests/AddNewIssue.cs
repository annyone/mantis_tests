using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]
        public void AddNewIssueTest()
        {
            AccountData account = new AccountData("administrator", "password");
            ProjectData project = new ProjectData()
            {
                Id = "7"
            };
            IssueData issue = new IssueData()
            {
                Summary = "any text",
                Description = "another text",
                Category = "General"
            };
            app.Api.CreateNewIssue(account, project, issue);
        }


    }
}
