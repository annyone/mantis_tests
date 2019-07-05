namespace mantis_tests
{
    public class NavHelper : BaseHelper
    {
        private string baseURL;
        public NavHelper(AppManager manager, string baseURL)
           : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenMainPage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL + "login_page.php");
        }

        public void OpenManagePage()
        {
            driver.Navigate().GoToUrl(baseURL+ "manage_overview_page.php");
        }

        public void OpenManageProjectPage()
        {
            driver.Navigate().GoToUrl(baseURL + "manage_proj_page.php");
        }

    }
}
