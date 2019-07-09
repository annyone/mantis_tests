using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectHelper : BaseHelper
    {
        private string baseURL;
        public static Random rnd = new Random();

        public ProjectHelper(AppManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void Create(ProjectData project)
        {
            manager.Nav.OpenManageProjectPage();
            CreateProjectButton();
            FillNewProjectForm(project);
            SubmitNewProjectFormButton();
        }

        public void Delete(ProjectData project)
        {
            manager.Nav.OpenManageProjectPage();
            SelectProject(project.Id);
            DeleteProjectButton();
            ConfirmDeleteProjectButton();
        }

        private void ConfirmDeleteProjectButton()
        {
            driver.FindElement(By.CssSelector("input[value='Удалить проект']")).Click();
        }

        private void DeleteProjectButton()
        {
            driver.FindElement(By.CssSelector("form[id='project-delete-form'] input[type='submit']")).Click();
        }

        private void SelectProject(string id)
        {
            driver.FindElement(By.CssSelector("a[href='manage_proj_edit_page.php?project_id=" + id + "']")).Click();
        }

        public void IsExist()
        {
            AccountData account = new AccountData("administrator", "password");
            mantis.Mantis.ProjectData[] projectsList = manager.Api.GetProjectList(account);

            if (projectsList.Length==0)
            {
                ProjectData project = new ProjectData((rnd.Next()).ToString(), (rnd.Next()).ToString());
                manager.Api.CreateNewProject(account, project);
            }
            return;
        }

        private void CreateProjectButton()
        {
            driver.FindElement(By.CssSelector("form[action='manage_proj_create_page.php'] button")).Click();
        }

        private void FillNewProjectForm(ProjectData project)
        {
            InputText(By.Name("name"), project.Name);
            InputText(By.Name("description"), project.Description);
        }

        private void SubmitNewProjectFormButton()
        {
            driver.FindElement(By.CssSelector("form input[type='submit']")).Click();
        }
    }
}
