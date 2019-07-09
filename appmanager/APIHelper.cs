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

        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            mantis.Mantis.MantisConnectPortTypeClient client = new mantis.Mantis.MantisConnectPortTypeClient();
            mantis.Mantis.ProjectData project = new mantis.Mantis.ProjectData();
            project.name = projectData.Name;
            project.description = projectData.Description;
            client.mc_project_add(account.Username, account.Password, project);
        }

        public mantis.Mantis.ProjectData[] GetProjectList(AccountData account)
        {
            mantis.Mantis.MantisConnectPortTypeClient client = new mantis.Mantis.MantisConnectPortTypeClient();
            //mantis.Mantis.ProjectData project = new mantis.Mantis.ProjectData();
            mantis.Mantis.ProjectData[] list = client.mc_projects_get_user_accessible(account.Username, account.Password);
            return list;
        }
    }
}
