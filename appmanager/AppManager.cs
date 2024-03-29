﻿using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace mantis_tests
{
    public class AppManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; private set; }
        public FtpHelper Ftp { get; private set; }
        public JamesHepler James { get; private set; }
        public MailHelper Mail { get; private set; }
        public AuthHelper Auth { get; private set; }
        public NavHelper Nav { get; private set; }
        public ProjectHelper Project { get; private set; }
        public AdminHelper Admin { get; private set; }
        public APIHelper Api { get; private set; }

        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();

        private AppManager()
        {
            driver = new ChromeDriver(@"C:\Windows\SysWOW64");
            baseURL = "http://localhost:8080/mantisbt-2.21.1/";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHepler(this);
            Mail = new MailHelper(this);
            Auth = new AuthHelper(this);
            Nav = new NavHelper(this, baseURL);
            Project = new ProjectHelper(this, baseURL);
            Admin = new AdminHelper(this, baseURL);
            Api = new APIHelper(this);
        }

        ~AppManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static AppManager GetInstance()
        {
            if(! app.IsValueCreated)
            {
                AppManager newInstance = new AppManager();
                newInstance.driver.Url = "http://localhost:8080/mantisbt-2.21.1/";
                app.Value = newInstance;  
            }

            return app.Value;
        }

        public IWebDriver Driver
        {
            get { return driver; }             
        }
    }
}
