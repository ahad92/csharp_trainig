using System;
using OpenQA.Selenium;


namespace WebaddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
                : base(manager)
        {
        }


        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            return this;
        }


        internal ContactHelper Remove(int contactNum)
        {
            SelectContact(contactNum);
            RemoveContact();
            AcceptAlert();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(int contactNum, ContactData newData)
        {

            manager.Navigator.GoToAddContactsPage();
            SelectContact(contactNum);
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToAddContactsPage();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
     
            driver.FindElement(By.Name("update")).Click();
            return this;
           
        }

        private ContactHelper InitContactModification()
        {
  //          driver.FindElement(By.XPath($"//input[@name='selected[]']['{index}']")).Click();
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath($"//input[@name='selected[]']['{index}']")).Click();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddContactsPage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            return this;
        }


        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

    }
}
