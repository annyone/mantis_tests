﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper : BaseHelper
    {
        private string baseURL;
        public AdminHelper(AppManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("div.table-responsive tbody tr"));
            foreach(IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                int id = Convert.ToInt32(m.Value);

                accounts.Add(new AccountData(name, id));
            }

            return accounts;
        }

        public void DeleteAccount (AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.CssSelector("input[value='Удалить учётную запись']")).Click();
            driver.FindElement(By.CssSelector("input[value='Удалить учётную запись']")).Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseURL + "login_page.php";

            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            driver.FindElement(By.Name("password")).SendKeys("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            return driver;
        }
    }
}
