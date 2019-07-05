using OpenQA.Selenium;

namespace mantis_tests
{
    public class AuthHelper : BaseHelper
    {
        public AuthHelper(AppManager manager) : base(manager) { }

        public void LogIn(AccountData account)
        {
            InputText(By.Name("username"), account.Username);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            InputText(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }
    }
}