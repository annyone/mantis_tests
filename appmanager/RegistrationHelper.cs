using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class RegistrationHelper : BaseHelper
    {
        public RegistrationHelper(AppManager manager) : base(manager) { }

        internal void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            string url = GetConfirmationUrl(account);
            FillPasswordForm(url);
            SubmitPasswordForm();
        }

        private string GetConfirmationUrl(AccountData account)
        {
            string message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void FillPasswordForm(string url)
        {
            throw new NotImplementedException();
        }

        private void SubmitPasswordForm()
        {
            throw new NotImplementedException();
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.21.1/login_page.php";
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.XPath("//a[@href='signup_page.php']")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }
    }
}
