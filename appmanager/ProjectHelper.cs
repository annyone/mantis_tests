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

        public ProjectHelper(AppManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void Create()
        {
            manager.Nav.OpenMainPage();
            manager.Nav.OpenManagePage();
            manager.Nav.OpenManageProjectPage();
            CreateProjectButton();
            FillNewProjectForm();
            SubmitNewProjectFormButton();
        }

        public void Modify()
        {
            //
        }

        public void Delete()
        {
            //
        }

        public void IsExist()
        {


        }

        private void CreateProjectButton()
        {
            driver.FindElement(By.CssSelector("form[action='manage_proj_create_page.php'] button")).Click();
        }

        private void FillNewProjectForm()
        {
            InputText(By.Name("name"), "ProjectName");
            InputText(By.Name("description"), "ProjectDescription");
        }

        private void SubmitNewProjectFormButton()
        {
            driver.FindElement(By.CssSelector("form input[type='submit']")).Click();
        }
    }
}
