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

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php/"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
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
