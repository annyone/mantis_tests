using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : BaseHelper
    {
        public APIHelper(AppManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            mantis.Mantis.MantisConnectPortTypeClient client = new mantis.Mantis.MantisConnectPortTypeClient();
            mantis.Mantis.IssueData issue = new mantis.Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new mantis.Mantis.ObjectRef();
            issue.project.id = project.Id;

            client.mc_issue_add(account.Username, account.Password, issue);
        }
    }
}
