using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace WebaddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this,baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated )
            {
                app.Value = new ApplicationManager();
            }
            return app.Value;
        }

         ~ApplicationManager()
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

        public IWebDriver Driver 
        { 
            get => driver;
        }


        public LoginHelper Auth
        {
            get => loginHelper;
        }

        public NavigationHelper Navigator
        {
            get => navigator;
        }

        public GroupHelper Groups
        {
            get => groupHelper;
        }

        public ContactHelper Contacts
        {
            get => contactHelper;
        }
 
    }
}
