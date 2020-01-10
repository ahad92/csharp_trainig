using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                LogOut();
            }
            Type(By.Name("username"), account.Name);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.ClassName("user_info"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUsername() == account.Name;

        }

        public string GetLoggedUsername()
        {
            string text = driver.FindElement((By.ClassName("user-info"))).Text;
            System.Console.WriteLine(text);
            return text.Substring(1, text.Length - 2);
        }

        public void LogOut()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.XPath("//i[2]")).Click();
                driver.FindElement(By.LinkText("Выход")).Click();
            }
            //waiting
            int attempt = 0;
            while (IsLoggedIn() && attempt < 10000)
            {
                System.Threading.Thread.Sleep(2);
                attempt++;
            }
        }

    }
}