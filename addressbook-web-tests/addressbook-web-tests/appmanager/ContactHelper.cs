﻿using System;
using System.Collections.Generic;
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

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddContactsPage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public List<ContactData> GetContactList() 
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
 //           ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name ='entry']"));
            ICollection<IWebElement> FirstNames = driver.FindElements(By.XPath("//tr[@name ='entry']//td[3]"));
            ICollection<IWebElement> Lastnames = driver.FindElements(By.XPath("//tr[@name ='entry']//td[2]"));
            foreach (IWebElement element in FirstNames)
            {
                contacts.Add(new ContactData(element.Text, element.Text));
            }

            foreach (IWebElement element in Lastnames)
            {
                contacts.Add(new ContactData(element.Text, element.Text));
            }
            return contacts;
        }


        public void Remove(int contactNum)
        {
           manager.Navigator.GoToHomePage();      
            SelectContact(contactNum);
            RemoveContact();
            AcceptAlert();
            manager.Navigator.GoToHomePage();
        }

        public bool IsContactExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper Modify(int contactNum,int rowNumber,ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            if (!IsContactExist())
            {
                Create(newData);
            }
            SelectContact(contactNum);
            InitContactModification(rowNumber);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;        
        }

        private ContactHelper InitContactModification(int index)
        {   
            driver.FindElement(By.XPath($"//tr[@name ='entry'][{index+1}]//input[@type='checkbox']/../..//img[@alt='Edit']")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
           driver.FindElement(By.XPath($"//tr[@name ='entry'][{index+1}]//input[@type='checkbox']")).Click();
           return this;
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("email"), contact.Email);
            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
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
