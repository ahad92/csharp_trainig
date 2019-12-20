using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace WebaddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
                : base(manager)
        {
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

        public int GetContactCount()
        {            
            return driver.FindElements(By.XPath("//tr[@name ='entry']")).Count;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> rows = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in rows)
                {
                    ICollection<IWebElement> td = element.FindElements(By.TagName("td"));

                    contactCache.Add(new ContactData(td.ElementAt(2).Text , td.ElementAt(1).Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                    });
                }
            }
            return contactCache;
        }

        public void Remove(int contactNum)
        {
           manager.Navigator.GoToHomePage();
            SelectContact(contactNum);
            RemoveContact();
            AcceptAlert();
            AssertThatContactDeleted();
            manager.Navigator.GoToGroupsPage();
            manager.Navigator.GoToHomePage(); // it need for updating contacts data in home page 
        }

        private bool AssertThatContactDeleted()
        {
  //         return IsElementPresent(By.CssSelector("div.msgbox"));
           return IsElementPresent(By.LinkText("Record successful deleted"));
        }

        public bool IsContactExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper Modify(int contactNum, ContactData newContactData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contactNum);
            InitContactModification(contactNum);
            FillContactForm(newContactData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;        
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        private ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
               .FindElements(By.TagName("td"))[7]
               .FindElement(By.TagName("a")).Click();

            return this;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            string homePage = driver.FindElement(By.XPath($"//table[@id='maintable']//tr[' + {index + 1} + ']//td[10]//a//img")).GetAttribute("title");
            
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
                HomePage = homePage
            };
        }

        public ContactData GetContactInformationFromForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email1 = email,
                Email2 = email2,
                Email3 = email3,
                HomePage = "http://" + homePage,
            };
        }

        public string getContactInformationFromContactDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            GoToContactDetailedInfo(index);
            return driver.FindElement(By.Id("content")).Text;
        }

        private string GetDateFormatted(string day, string month, string year)
        {
            var bday = String.Empty;
            bday += (String.IsNullOrEmpty(day) || day.Equals("-") ? String.Empty : $"{day}. ");
            bday += (String.IsNullOrEmpty(month) || month.Equals("-") ? String.Empty : $"{month} ");
            bday += (String.IsNullOrEmpty(year) ? String.Empty : $"{year}");
            return bday;
        }

        public string GetAllContactInformationFromForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string allInfo;

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string secondaryPhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            //detailed information
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            // birthday & anniversary 
            string birthday =
                GetDateFormatted(driver.FindElement(By.Name("bday")).GetAttribute("value"),
                driver.FindElement(By.Name("bmonth")).GetAttribute("value"),
                driver.FindElement(By.Name("byear")).GetAttribute("value"));

            string anniversary =
                GetDateFormatted(driver.FindElement(By.Name("aday")).GetAttribute("value"),
                driver.FindElement(By.Name("amonth")).FindElement(By.CssSelector("option[selected=selected]")).Text,
                driver.FindElement(By.Name("ayear")).GetAttribute("value"));

            string personInfo = ((String.IsNullOrEmpty(firstName.Trim()) ? String.Empty : $"{firstName} ") +
                (String.IsNullOrEmpty(middlename.Trim()) ? String.Empty : $"{middlename} ") +
                (String.IsNullOrEmpty(lastName.Trim()) ? String.Empty : $"{lastName}")).Trim();

            allInfo = personInfo +
                Environment.NewLine +
                (String.IsNullOrEmpty(nickname) ? String.Empty : $"{nickname}{Environment.NewLine}") +
                (String.IsNullOrEmpty(title) ? String.Empty : $"{title}{Environment.NewLine}") +
                (String.IsNullOrEmpty(company) ? String.Empty : $"{company}{Environment.NewLine}") +
                (String.IsNullOrEmpty(address) ? String.Empty : $"{address}{Environment.NewLine}") +
                Environment.NewLine +
                (String.IsNullOrEmpty(homePhone) ? String.Empty : $"H: {homePhone}{Environment.NewLine}") +
                (String.IsNullOrEmpty(mobilePhone) ? String.Empty : $"M: {mobilePhone}{Environment.NewLine}") +
                (String.IsNullOrEmpty(workPhone) ? String.Empty : $"W: {workPhone}{Environment.NewLine}") +
                (String.IsNullOrEmpty(fax) ? String.Empty : $"F: {fax}{Environment.NewLine}") +
                Environment.NewLine +
                (String.IsNullOrEmpty(email) ? String.Empty : $"{email}{Environment.NewLine}") +
                (String.IsNullOrEmpty(email2) ? String.Empty : $"{email2}{Environment.NewLine}") +
                (String.IsNullOrEmpty(email3) ? String.Empty : $"{email3}{Environment.NewLine}") +
                $"Homepage:{Environment.NewLine}{homepage}{Environment.NewLine}" +
                Environment.NewLine +
                (String.IsNullOrEmpty(birthday) ? String.Empty : $"Birthday {birthday}{Environment.NewLine}") +
                (String.IsNullOrEmpty(anniversary) ? String.Empty : $"Anniversary {anniversary}{Environment.NewLine}") +
                Environment.NewLine +
                (String.IsNullOrEmpty(address2) ? String.Empty : $"{address2}{Environment.NewLine}") +
                Environment.NewLine +
                (String.IsNullOrEmpty(secondaryPhone) ? String.Empty : $"P: {secondaryPhone}{Environment.NewLine}") +
                Environment.NewLine +
                notes;

            return allInfo;
        }

        private void GoToContactDetailedInfo(int index)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']//tr[' + {index + 1} + ']//td[7]//a//img")).Click();
        }

        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            GoToContactDetailedInfo(index);
            return driver.FindElement(By.Id("content")).Text;
        }
        public String GetContactInformationFromDetailsAsString(int index)
        {
            manager.Navigator.GoToHomePage();
            GoToContactDetailedInfo(index);

            string textData = driver.FindElement(By.XPath(@"//div[@id='content']")).Text;
            Regex r = new Regex(@"([MWH]:\s)|(\r)|(\n)");

            return r.Replace(textData, "");
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
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
            
            Type(By.Name("email1"), contact.Email1);
            Type(By.Name("email2"), contact.Email2);           
            Type(By.Name("email3"), contact.Email3);

            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("homepage"), contact.HomePage);

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
            contactCache = null;
            return this;
        }

        public ContactHelper AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

    }
}
