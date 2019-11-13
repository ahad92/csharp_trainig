using OpenQA.Selenium;

namespace WebaddressbookTests
{
    public class LoginHelper : HelperBase
    {
     
        public LoginHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public LoginHelper Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            return this;

        }
    }
}
