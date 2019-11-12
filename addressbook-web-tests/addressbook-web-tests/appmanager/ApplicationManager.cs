using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace WebaddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        private object verificationErrors;

        public ApplicationManager()
        {
            loginHelper = new LoginHelper(driver);
            navigator = new NavigationHelper(driver,baseURL);
            groupHelper = new GroupHelper(driver);
        }

        public LoginHelper Auth
        {
            get => loginHelper;
        }

        public NavigationHelper Navigator
        {
            get => navigator;
        }

        public GroupHelper GroupHelper
        {
            get => groupHelper;
        }

        public void Stop()

         {
            try
                {
                    driver.Quit();
                }
            catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
                Assert.AreEqual("", verificationErrors.ToString());
         }
    }
}
