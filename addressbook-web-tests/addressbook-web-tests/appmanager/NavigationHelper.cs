using OpenQA.Selenium;


namespace WebaddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public NavigationHelper GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook");
            return this;
        }

        public NavigationHelper GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public NavigationHelper GoToAddContactsPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public NavigationHelper Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

    }
}
