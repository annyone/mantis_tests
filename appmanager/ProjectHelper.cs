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
        }

        public void IsExist()
        {
            if (driver.Url == baseURL + "manage_proj_page.php"
                && !IsElementPresent(By.CssSelector("div[class='table-responsive']")))
            {
                ProjectData project = new ProjectData((rnd.Next()).ToString(), (rnd.Next()).ToString());
                Create(project);
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
